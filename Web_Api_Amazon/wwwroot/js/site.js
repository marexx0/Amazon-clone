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