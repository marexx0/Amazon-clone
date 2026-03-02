(() => {
    const tabLinks = document.querySelectorAll('.tab-link');
    const tabPanels = document.querySelectorAll('.tab-panel');

    tabLinks.forEach((link) => {
        link.addEventListener('click', () => {
            const target = link.getAttribute('data-tab');
            tabLinks.forEach((item) => item.classList.remove('is-active'));
            tabPanels.forEach((panel) => panel.classList.remove('is-active'));
            link.classList.add('is-active');
            const panel = document.getElementById(target);
            if (panel) {
                panel.classList.add('is-active');
            }
        });
    });

    const thumbnails = document.querySelectorAll('.thumbnail');
    const mainImage = document.querySelector('.main-image-card img');
    thumbnails.forEach((thumb) => {
        thumb.addEventListener('click', () => {
            const imageUrl = thumb.getAttribute('data-image');
            if (mainImage && imageUrl) {
                mainImage.src = imageUrl;
            }
            thumbnails.forEach((item) => item.classList.remove('is-active'));
            thumb.classList.add('is-active');
        });
    });

    const qtyInput = document.querySelector('.quantity-control input');
    const selectedOptionsInput = document.getElementById('selected-options-json');
    document.querySelectorAll('.qty-btn').forEach((btn) => {
        btn.addEventListener('click', () => {
            if (!qtyInput) return;
            const direction = btn.getAttribute('data-qty');
            const current = parseInt(qtyInput.value || '1', 10);
            if (direction === 'increase') {
                qtyInput.value = current + 1;
            }
            if (direction === 'decrease' && current > 1) {
                qtyInput.value = current - 1;
            }
        });
    });

    const colorButtons = document.querySelectorAll('.color-option');
    colorButtons.forEach((btn) => {
        btn.addEventListener('click', () => {
            colorButtons.forEach((item) => item.classList.remove('is-selected'));
            btn.classList.add('is-selected');
            const color = btn.getAttribute('data-color');
            const selectedColorName = btn.closest('.option-group')?.querySelector('.option-value');

            if (selectedColorName && color) {
                selectedColorName.textContent = color;
            }

            updateSelectedOptionsJson();

        });
    });

    const sizeButtons = document.querySelectorAll('.size-option');
    sizeButtons.forEach((btn) => {
        btn.addEventListener('click', () => {
            sizeButtons.forEach((item) => item.classList.remove('is-selected'));
            btn.classList.add('is-selected');
            const selectedSize = btn.closest('.option-group')?.querySelector('.option-value');

            if (selectedSize) {
                selectedSize.textContent = btn.textContent?.trim() ?? '';
            }

            updateSelectedOptionsJson();

        });
    });

    const addToCartTrigger = document.getElementById('add-to-cart-trigger');
    const addToCartForm = addToCartTrigger?.closest('form');
    const favoriteToggle = document.getElementById('favorite-toggle');
    const favoriteFeedback = document.getElementById('favorite-feedback');
    const cartModal = document.getElementById('cart-modal');
    const closeCartModalElements = document.querySelectorAll('[data-close-cart-modal]');

    const selectedColorTarget = document.getElementById('modal-selected-color');
    const selectedSizeTarget = document.getElementById('modal-selected-size');
    const selectedQtyTarget = document.getElementById('modal-selected-qty');


    const updateSelectedOptionsJson = () => {
        if (!selectedOptionsInput) return;

        const options = {};
        document.querySelectorAll('.option-group').forEach((group) => {
            const label = group.querySelector('.option-label')?.textContent?.trim();
            const value = group.querySelector('.option-value')?.textContent?.trim();

            if (label && value) {
                options[label] = value;
            }
        });

        selectedOptionsInput.value = JSON.stringify(options);
    };

    const openCartModal = () => {
        if (!cartModal) return;

        const selectedColor = document.querySelector('.color-option.is-selected')?.getAttribute('data-color');
        const selectedSize = document.querySelector('.size-option.is-selected')?.textContent?.trim();
        const qty = qtyInput?.value || '1';

        if (selectedColorTarget && selectedColor) {
            selectedColorTarget.textContent = selectedColor;
        }

        if (selectedSizeTarget && selectedSize) {
            selectedSizeTarget.textContent = selectedSize;
        }

        if (selectedQtyTarget) {
            selectedQtyTarget.textContent = qty;
        }

        cartModal.hidden = false;
        cartModal.classList.add('is-open');
        cartModal.setAttribute('aria-hidden', 'false');
        document.body.style.overflow = 'hidden';
    };

    const closeCartModal = () => {
        if (!cartModal) return;
        cartModal.classList.remove('is-open');
        cartModal.setAttribute('aria-hidden', 'true');
        cartModal.hidden = true;
        document.body.style.overflow = '';
    };

    const setFavoriteState = (isFavorite) => {
        if (!favoriteToggle) return;

        favoriteToggle.dataset.isFavorite = `${isFavorite}`;
        favoriteToggle.classList.toggle('is-favorite', isFavorite);
        favoriteToggle.setAttribute('aria-label', isFavorite ? 'Remove from favorites' : 'Add to favorites');

        const icon = favoriteToggle.querySelector('span[aria-hidden="true"]');
        if (icon) {
            icon.textContent = isFavorite ? '♥' : '♡';
        }
    };

    updateSelectedOptionsJson();

    addToCartForm?.addEventListener('submit', async (event) => {
        event.preventDefault();

        addToCartTrigger?.setAttribute('disabled', 'disabled');

        try {
            const response = await fetch(addToCartForm.action, {
                method: 'POST',
                body: new FormData(addToCartForm),
                credentials: 'same-origin'
            });

            if (!response.ok) {
                throw new Error(`Add to cart failed with status ${response.status}`);
            }

            openCartModal();
        }
        catch {
            addToCartForm.submit();
        }
        finally {
            addToCartTrigger?.removeAttribute('disabled');
        }
    });

    favoriteToggle?.addEventListener('click', async () => {
        const productId = favoriteToggle.dataset.productId;
        const toggleUrl = favoriteToggle.dataset.toggleUrl;
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

        if (!productId || !toggleUrl || !token) {
            return;
        }

        favoriteToggle.setAttribute('disabled', 'disabled');

        try {
            const payload = new URLSearchParams();
            payload.set('productId', productId);
            payload.set('__RequestVerificationToken', token);

            const response = await fetch(toggleUrl, {
                method: 'POST',
                credentials: 'same-origin',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                },
                body: payload.toString()
            });

            if (!response.ok) {
                throw new Error(`Favorite request failed with status ${response.status}`);
            }

            const result = await response.json();
            setFavoriteState(Boolean(result.isFavorite));

            if (favoriteFeedback && typeof result.message === 'string') {
                favoriteFeedback.textContent = result.message;
            }
        }
        catch {
            if (favoriteFeedback) {
                favoriteFeedback.textContent = 'Unable to update favorites right now. Please try again.';
            }
        }
        finally {
            favoriteToggle.removeAttribute('disabled');
        }
    });


    closeCartModalElements.forEach((element) => {
        element.addEventListener('click', closeCartModal);
    });

    document.addEventListener('keydown', (event) => {
        if (event.key === 'Escape' && cartModal?.classList.contains('is-open')) {
            closeCartModal();
        }
    });

})();