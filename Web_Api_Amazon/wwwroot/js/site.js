document.addEventListener('DOMContentLoaded', function () {

    var profileBtn = document.getElementById('profileBtn');
    var profileDropdown = document.getElementById('profileDropdown');
    var overlay = document.getElementById('profileOverlay');
    var catBtn = document.getElementById('catBtn');
    var catDropdown = document.getElementById('catDropdown');

    function openProfile() {
        closeCat();
        profileDropdown.classList.add('open');
        profileBtn.classList.add('active');
        overlay.classList.add('active');
    }
    function closeProfile() {
        profileDropdown.classList.remove('open');
        profileBtn.classList.remove('active');
        overlay.classList.remove('active');
    }
    function openCat() {
        closeProfile();
        catDropdown.classList.add('open');
        catBtn.classList.add('active');
        overlay.classList.add('active');
    }
    function closeCat() {
        if (!catBtn || !catDropdown) return;
        catDropdown.classList.remove('open');
        catBtn.classList.remove('active');
        overlay.classList.remove('active');
    }
    function closeAll() {
        closeProfile();
        closeCat();
    }

    profileBtn?.addEventListener('click', function (e) {
        e.stopPropagation();
        profileDropdown.classList.contains('open') ? closeProfile() : openProfile();
    });

    catBtn?.addEventListener('click', function (e) {
        e.stopPropagation();
        catDropdown.classList.contains('open') ? closeCat() : openCat();
    });

    overlay?.addEventListener('click', closeAll);
    document.addEventListener('click', closeAll);

    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') closeAll();
    });

    // Зберігаємо позицію скролу
    document.querySelectorAll('.cat-dropdown a').forEach(function (link) {
        link.addEventListener('click', function () {
            sessionStorage.setItem('scrollPos', window.scrollY);
        });
    });

});

window.addEventListener('load', function () {
    var scrollPos = sessionStorage.getItem('scrollPos');
    if (scrollPos) {
        window.scrollTo(0, parseInt(scrollPos));
        sessionStorage.removeItem('scrollPos');
    }
});