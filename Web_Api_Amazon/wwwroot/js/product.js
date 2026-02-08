document.addEventListener("DOMContentLoaded", () => {
    const colorOptions = document.querySelectorAll(".color-option");
    const sizeOptions = document.querySelectorAll(".size-option");
    const tabLinks = document.querySelectorAll(".tab-link");
    const tabPanels = document.querySelectorAll(".tab-panel");
    const qtyButtons = document.querySelectorAll(".qty-btn");

    colorOptions.forEach((option) => {
        option.addEventListener("click", () => {
            colorOptions.forEach((btn) => btn.classList.remove("is-selected"));
            option.classList.add("is-selected");
        });
    });

    sizeOptions.forEach((option) => {
        option.addEventListener("click", () => {
            sizeOptions.forEach((btn) => btn.classList.remove("is-selected"));
            option.classList.add("is-selected");
        });
    });

    tabLinks.forEach((link) => {
        link.addEventListener("click", () => {
            const target = link.getAttribute("data-tab");
            tabLinks.forEach((btn) => btn.classList.remove("is-active"));
            tabPanels.forEach((panel) => panel.classList.remove("is-active"));
            link.classList.add("is-active");
            document.getElementById(target)?.classList.add("is-active");
        });
    });

    qtyButtons.forEach((button) => {
        button.addEventListener("click", () => {
            const input = button.closest(".quantity-control")?.querySelector("input");
            if (!input) return;
            const currentValue = Number(input.value || 1);
            if (button.dataset.qty === "increase") {
                input.value = String(currentValue + 1);
            }
            if (button.dataset.qty === "decrease") {
                input.value = String(Math.max(1, currentValue - 1));
            }
        });
    });
});