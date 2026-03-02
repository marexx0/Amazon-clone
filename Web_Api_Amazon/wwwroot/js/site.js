// Profile dropdown
(function () {
    var btn = document.getElementById('profileBtn');
    var dropdown = document.getElementById('profileDropdown');
    var overlay = document.getElementById('profileOverlay');

    if (!btn || !dropdown || !overlay) return;

    function open() {
        dropdown.classList.add('open');
        btn.classList.add('active');
        overlay.classList.add('active');
    }

    function close() {
        dropdown.classList.remove('open');
        btn.classList.remove('active');
        overlay.classList.remove('active');
    }

    btn.addEventListener('click', function (e) {
        e.stopPropagation();
        dropdown.classList.contains('open') ? close() : open();
    });

    overlay.addEventListener('click', close);

    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') close();
    });

    dropdown.addEventListener('click', function (e) {
        e.stopPropagation();
    });
})();
// Category dropdown
(function () {
    var btn = document.getElementById('catBtn');
    var dropdown = document.getElementById('catDropdown');
    var profileDropdown = document.getElementById('profileDropdown');
    var profileBtn = document.getElementById('profileBtn');
    var overlay = document.getElementById('profileOverlay');

    if (!btn || !dropdown) return;

    function openCat() {
        // закрити profile якщо відкритий
        if (profileDropdown) profileDropdown.classList.remove('open');
        if (profileBtn) profileBtn.classList.remove('active');

        dropdown.classList.add('open');
        btn.classList.add('active');
        if (overlay) overlay.classList.add('active');
    }

    function closeCat() {
        dropdown.classList.remove('open');
        btn.classList.remove('active');
        if (overlay) overlay.classList.remove('active');
    }

    btn.addEventListener('click', function (e) {
        e.stopPropagation();
        dropdown.classList.contains('open') ? closeCat() : openCat();
    });

    overlay.addEventListener('click', closeCat);

    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') closeCat();
    });

    dropdown.addEventListener('click', function (e) {
        e.stopPropagation();
    });
})();
// Зберігаємо позицію скролу перед переходом
document.querySelectorAll('.cat-dropdownI a').forEach(function (link) {
    link.addEventListener('click', function (e) {
        e.stopPropagation();
        sessionStorage.setItem('scrollPos', window.scrollY);
    });
});

// Відновлюємо позицію після завантаження сторінки
window.addEventListener('load', function () {
    var scrollPos = sessionStorage.getItem('scrollPos');
    if (scrollPos) {
        window.scrollTo(0, parseInt(scrollPos));
        sessionStorage.removeItem('scrollPos');
    }
});

// Wishlist toggle without page refresh
(function () {
    const wishlistForms = document.querySelectorAll('.wishlist-form');
    if (!wishlistForms.length) return;

    const updateWishlistButton = function (form, isFavorite) {
        const button = form.querySelector('.wishlist-btn');
        if (!button) return;

        button.classList.toggle('is-favorite', isFavorite);
        button.setAttribute('aria-label', isFavorite ? 'Remove from favorites' : 'Add to favorites');

        const newAction = isFavorite ? 'Remove' : 'Add';
        const oldAction = isFavorite ? 'Add' : 'Remove';
        form.action = form.action.replace(`/Favorites/${oldAction}`, `/Favorites/${newAction}`);
    };

    const syncWishlistButtonsForProduct = function (productId, isFavorite) {
        if (!productId) return;

        wishlistForms.forEach(function (candidateForm) {
            const candidateProductId = candidateForm.querySelector('input[name="productId"]')?.value;
            if (candidateProductId === productId) {
                updateWishlistButton(candidateForm, isFavorite);
            }
        });
    };

    wishlistForms.forEach(function (form) {
        form.addEventListener('submit', async function (event) {
            event.preventDefault();

            const button = form.querySelector('.wishlist-btn');
            if (!button) {
                form.submit();
                return;
            }

            button.setAttribute('disabled', 'disabled');

            try {
                const response = await fetch(form.action, {
                    method: 'POST',
                    body: new FormData(form),
                    credentials: 'same-origin',
                    headers: {
                        'X-Requested-With': 'XMLHttpRequest'
                    }
                });

                if (response.status === 401) {
                    const result = await response.json();
                    if (result?.redirectUrl) {
                        window.location.href = result.redirectUrl;
                        return;
                    }
                    throw new Error('Authentication required for favorites');
                }

                if (!response.ok) {
                    throw new Error(`Wishlist request failed with status ${response.status}`);
                }

                const result = await response.json();
                const isFavorite = Boolean(result.isFavorite);
                const productId = form.querySelector('input[name="productId"]')?.value ?? '';

                syncWishlistButtonsForProduct(productId, isFavorite);
                document.dispatchEvent(new CustomEvent('favorites:changed', {
                    detail: {
                        productId,
                        isFavorite
                    }
                }));
            } catch {
                form.submit();
            } finally {
                button.removeAttribute('disabled');
            }
        });
    });
})();