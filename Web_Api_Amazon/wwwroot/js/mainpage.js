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