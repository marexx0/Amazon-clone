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
// Клік по підкатегорії
document.querySelectorAll('.cat-dropdownI a').forEach(function (link) {
    link.addEventListener('click', function (e) {
        e.preventDefault(); // не йти за посиланням
        var categoryId = this.getAttribute('data-category-id');

        // Тут ми будемо показувати продукти цієї категорії
        showProducts(categoryId);
    });
});
function showProducts(categoryId) {
    document.querySelectorAll('.product-card').forEach(function (card) {
        // У кожної карточки повинен бути data-category-id
        if (card.getAttribute('data-category-id') === categoryId) {
            card.style.display = 'block';
        } else {
            card.style.display = 'none';
        }
    });
}
