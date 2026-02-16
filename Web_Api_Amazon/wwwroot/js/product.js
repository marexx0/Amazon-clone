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
        });
    });
})();