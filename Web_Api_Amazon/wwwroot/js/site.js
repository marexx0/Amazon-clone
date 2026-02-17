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
