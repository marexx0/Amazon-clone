// Клік по категорії для показу підкатегорій
document.querySelectorAll('.category-itemI').forEach(function (catItem) {
    var dropdown = catItem.querySelector('.cat-dropdownI');

    catItem.addEventListener('click', function (e) {
        e.stopPropagation(); // щоб клік не пішов далі

        // Закриваємо всі інші підкатегорії
        document.querySelectorAll('.cat-dropdownI').forEach(function (dd) {
            if (dd !== dropdown) {
                dd.classList.remove('open');
            }
        });

        // Відкриваємо/закриваємо свою
        dropdown.classList.toggle('open');
    });
});

// Закриття при кліку поза категоріями
document.addEventListener('click', function () {
    document.querySelectorAll('.cat-dropdownI').forEach(function (dd) {
        dd.classList.remove('open');
    });
});
