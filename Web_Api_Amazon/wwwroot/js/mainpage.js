// Клік по категорії — тоглить дропдаун
document.querySelectorAll('.category-itemI').forEach(function (catItem) {
    var dropdown = catItem.querySelector('.cat-dropdownI');

    catItem.addEventListener('click', function (e) {
        e.stopPropagation();

        document.querySelectorAll('.cat-dropdownI').forEach(function (dd) {
            if (dd !== dropdown) dd.classList.remove('open');
        });

        dropdown.classList.toggle('open');
    });
});

// Закриття при кліку поза
document.addEventListener('click', function () {
    document.querySelectorAll('.cat-dropdownI').forEach(function (dd) {
        dd.classList.remove('open');
    });
});

// Клік по підкатегорії — просто дозволяємо перейти за посиланням
document.querySelectorAll('.cat-dropdownI a').forEach(function (link) {
    link.addEventListener('click', function (e) {
        e.stopPropagation(); // щоб не закрити дропдаун до переходу
        // НЕ preventDefault — нехай href спрацює і контролер відфільтрує
    });
});
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

// Watch more: progressively reveal more cards in each section
(function () {
    var sections = document.querySelectorAll('section');
    if (!sections.length) return;

    sections.forEach(function (section) {
        var grid = section.querySelector('.products-grid');
        var watchMoreBtn = section.querySelector('.watch-more-btn');
        if (!grid || !watchMoreBtn) return;

        var cards = Array.prototype.slice.call(grid.querySelectorAll('.product-card'));
        if (!cards.length) {
            var emptyWrap = watchMoreBtn.closest('.section-watch-more');
            if (emptyWrap) emptyWrap.remove();
            return;
        }

        var isMobile = window.matchMedia('(max-width: 768px)').matches;
        var initialVisible = isMobile ? 4 : 6;
        var step = isMobile ? 2 : 3;
        var visibleCount = Math.min(initialVisible, cards.length);

        function applyVisibility() {
            cards.forEach(function (card, index) {
                card.style.display = index < visibleCount ? '' : 'none';
            });

            var watchMoreWrap = watchMoreBtn.closest('.section-watch-more');
            if (!watchMoreWrap) return;

            if (visibleCount >= cards.length) {
                watchMoreWrap.style.display = 'none';
            } else {
                watchMoreWrap.style.display = 'flex';
            }
        }

        watchMoreBtn.addEventListener('click', function (e) {
            e.preventDefault();
            visibleCount = Math.min(visibleCount + step, cards.length);
            applyVisibility();
        });

        applyVisibility();
    });
})();