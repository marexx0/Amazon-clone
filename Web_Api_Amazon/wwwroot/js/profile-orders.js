(function () {
    const cards = Array.from(document.querySelectorAll('.js-order-card'));

    // ===== Drawer Elements =====
    const drawer = document.getElementById('orderDetailsDrawer');
    const overlay = document.getElementById('ordersOverlay');
    const closeBtn = document.getElementById('orderDetailsClose');
    const title = document.getElementById('drawerOrderTitle');
    const location = document.getElementById('drawerOrderLocation');
    const date = document.getElementById('drawerOrderDate');
    const subtotal = document.getElementById('drawerOrderSubtotal');
    const shipping = document.getElementById('drawerOrderShipping');
    const tax = document.getElementById('drawerOrderTax');
    const total = document.getElementById('drawerOrderTotal');
    const status = document.getElementById('drawerOrderStatus');
    const estimated = document.getElementById('drawerEstimatedDelivery');
    const paymentTitle = document.getElementById('drawerPaymentTitle');
    const paymentSubtitle = document.getElementById('drawerPaymentSubtitle');
    const deliveryTitle = document.getElementById('drawerDeliveryTitle');
    const deliveryAddress = document.getElementById('drawerDeliveryAddress');
    const timelineOrderPlaced = document.getElementById('drawerTimelineOrderPlaced');
    const timelinePaymentConfirmed = document.getElementById('drawerTimelinePaymentConfirmed');
    const timelineShipped = document.getElementById('drawerTimelineShipped');
    const orderItemsContainer = document.getElementById('drawerOrderItems');

    // ===== Toolbar & Popover Elements =====
    const filterButtons = Array.from(document.querySelectorAll('.orders-filter'));
    const sortBtn = document.getElementById('ordersSortBtn');
    const statusBtn = document.getElementById('ordersStatusBtn');
    const customRangeBtn = document.getElementById('customRangeBtn');
    const rangePopover = document.getElementById('ordersDateRangePopover');
    const rangeSubmit = document.getElementById('ordersRangeSubmit');
    const rangeCancel = document.getElementById('ordersRangeCancel');

    // ===== Calendar Elements =====
    const calPrev = document.getElementById('calPrev');
    const calNext = document.getElementById('calNext');
    const calTitle = document.getElementById('calTitle');
    const calDays = document.getElementById('calDays');

    if (!cards.length) return;

    let closeTimer = null;

    // Calendar state
    let viewingDate = new Date();
    let tempCalStart = null;
    let tempCalEnd = null;

    // App State
    const state = {
        range: 'all',
        customStart: null,
        customEnd: null,
        sort: 'newest',
        status: 'all'
    };

    const toMoney = function (value) {
        const amount = Number(value || 0);
        return `$${amount.toFixed(2)}`;
    };

    const parseOrderDate = function (card) {
        const iso = card.dataset.orderDateIso;
        if (iso) {
            const parsed = new Date(iso);
            if (!Number.isNaN(parsed.getTime())) return parsed;
        }
        const fallback = new Date(card.dataset.orderDate || '');
        return Number.isNaN(fallback.getTime()) ? null : fallback;
    };

    const dayStart = function (date) {
        return new Date(date.getFullYear(), date.getMonth(), date.getDate());
    };

    const isInRange = function (date, days) {
        if (!date) return false;
        const now = new Date();
        const start = dayStart(now);
        start.setDate(start.getDate() - days + 1);
        return date >= start && date <= now;
    };

    // ===== Drawer Rendering =====
    const renderItems = function (items) {
        if (!orderItemsContainer) return;
        orderItemsContainer.innerHTML = '';

        if (!Array.isArray(items) || items.length === 0) {
            orderItemsContainer.innerHTML = '<p class="order-details-help-text">No items found for this order.</p>';
            return;
        }

        items.forEach(function (item) {
            const row = document.createElement('div');
            row.className = 'drawer-order-item';

            const imageUrl = item.imageUrl || item.ImageUrl || '';
            const name = item.name || item.Name || 'Item';
            const description = item.description || item.Description || 'Product details';
            const quantity = item.quantity ?? item.Quantity ?? 1;
            const propertyLabel = item.propertyLabel || item.PropertyLabel || 'Color';
            const propertyValue = item.propertyValue || item.PropertyValue || 'White';
            const totalPrice = item.total ?? item.Total ?? ((item.unitPrice ?? item.UnitPrice ?? 0) * quantity);

            row.innerHTML = `
                <img src="${imageUrl}" alt="${name}" class="drawer-order-item-image" />
                <div class="drawer-order-item-content">
                    <div class="drawer-order-item-name">${name}</div>
                    <div class="drawer-order-item-description">${description}</div>
                    <div class="drawer-order-item-meta">
                        <span>Quantity: ${quantity}</span>
                        <span>${propertyLabel}: ${propertyValue}</span>
                    </div>
                </div>
                <div class="drawer-order-item-price">${toMoney(totalPrice)}</div>
            `;
            orderItemsContainer.appendChild(row);
        });
    };

    const closeDrawer = function () {
        if (!drawer || !overlay) return;
        if (closeTimer) window.clearTimeout(closeTimer);

        drawer.classList.remove('open');
        overlay.classList.remove('open');
        overlay.hidden = true;
        drawer.setAttribute('aria-hidden', 'true');
        closeTimer = window.setTimeout(function () {
            drawer.hidden = true;
        }, 260);
        document.body.classList.remove('drawer-open');
    };

    const openDrawer = function (card) {
        if (!drawer || !overlay || !closeBtn) return;

        if (title) title.textContent = `Order #${card.dataset.orderId || '-'}`;
        if (location) location.textContent = card.dataset.orderLocation || 'Vienna, Austria';
        if (date) date.textContent = card.dataset.orderDate || '-';
        if (subtotal) subtotal.textContent = toMoney(card.dataset.orderSubtotal);
        if (shipping) shipping.textContent = toMoney(card.dataset.orderShipping);
        if (tax) tax.textContent = toMoney(card.dataset.orderTax);
        if (total) total.textContent = toMoney(card.dataset.orderTotal);
        if (status) status.textContent = card.dataset.orderStatus || 'Processing';
        if (paymentTitle) paymentTitle.textContent = card.dataset.orderPaymentTitle || 'Line card';
        if (paymentSubtitle) paymentSubtitle.textContent = card.dataset.orderPaymentSubtitle || 'Visa ending in ----, expires --/--';
        if (deliveryTitle) deliveryTitle.textContent = card.dataset.orderDeliveryTitle || 'Standard delivery';
        if (deliveryAddress) deliveryAddress.textContent = card.dataset.orderDeliveryAddress || 'Address not provided';

        const shortDate = (card.dataset.orderDate || '-').split(',')[0];
        if (timelineOrderPlaced) timelineOrderPlaced.textContent = `Order placed — ${shortDate}`;
        if (timelinePaymentConfirmed) timelinePaymentConfirmed.textContent = `Payment confirmed — ${shortDate}`;
        if (timelineShipped) timelineShipped.textContent = `Shipped — ${shortDate}`;
        if (estimated) estimated.textContent = `Out for delivery — ${card.dataset.orderEstimated || '-'}`;

        let orderItems = [];
        if (card.dataset.orderItems) {
            try { orderItems = JSON.parse(card.dataset.orderItems); } catch { }
        }
        renderItems(orderItems);

        if (closeTimer) { window.clearTimeout(closeTimer); closeTimer = null; }
        drawer.hidden = false;
        drawer.classList.add('open');
        overlay.hidden = false;
        overlay.classList.add('open');
        drawer.setAttribute('aria-hidden', 'false');
        document.body.classList.add('drawer-open');
    };

    // ===== Filtering & Sorting =====
    const updateSectionVisibility = function () {
        document.querySelectorAll('.orders-section').forEach(function (section) {
            const hasVisible = Array.from(section.querySelectorAll('.js-order-card'))
                .some(card => card.style.display !== 'none');
            section.style.display = hasVisible ? '' : 'none';
        });
    };

    const applyFiltersAndSort = function () {
        cards.forEach(function (card) {
            const orderDate = parseOrderDate(card);
            const cardStatus = (card.dataset.orderStatus || '').toLowerCase();
            let matchesRange = true;

            if (state.range === 'today') {
                matchesRange = orderDate ? dayStart(orderDate).getTime() === dayStart(new Date()).getTime() : false;
            } else if (state.range === '7') {
                matchesRange = isInRange(orderDate, 7);
            } else if (state.range === '30') {
                matchesRange = isInRange(orderDate, 30);
            } else if (state.range === 'custom') {
                if (!orderDate || !state.customStart || !state.customEnd) {
                    matchesRange = false;
                } else {
                    matchesRange = orderDate >= state.customStart && orderDate <= state.customEnd;
                }
            }

            const matchesStatus = state.status === 'all' ? true :
                (state.status === 'intransit' ? cardStatus === 'in transit' : cardStatus === state.status);

            card.style.display = matchesRange && matchesStatus ? '' : 'none';
        });

        document.querySelectorAll('.orders-grid').forEach(function (grid) {
            const cardsInGrid = Array.from(grid.querySelectorAll('.js-order-card'));
            cardsInGrid.sort(function (a, b) {
                const da = parseOrderDate(a)?.getTime() || 0;
                const db = parseOrderDate(b)?.getTime() || 0;
                return state.sort === 'newest' ? db - da : da - db;
            });
            cardsInGrid.forEach(card => grid.appendChild(card));
        });

        updateSectionVisibility();
    };

    // ===== Calendar Component logic =====
    const renderCalendar = function () {
        calDays.innerHTML = '';
        const year = viewingDate.getFullYear();
        const month = viewingDate.getMonth();

        // Update Title
        calTitle.textContent = new Intl.DateTimeFormat('en-US', { month: 'long', year: 'numeric' }).format(viewingDate);

        const firstDay = new Date(year, month, 1).getDay();
        const daysInMonth = new Date(year, month + 1, 0).getDate();

        // Empty cells before start of month
        for (let i = 0; i < firstDay; i++) {
            const empty = document.createElement('div');
            empty.className = 'calendar-day empty';
            calDays.appendChild(empty);
        }

        // Days
        for (let i = 1; i <= daysInMonth; i++) {
            const dayCell = document.createElement('div');
            dayCell.className = 'calendar-day';
            dayCell.textContent = i;

            const cellDate = new Date(year, month, i);
            cellDate.setHours(0, 0, 0, 0);
            const cellTime = cellDate.getTime();

            // Highlight Logic
            const startT = tempCalStart ? tempCalStart.getTime() : null;
            const endT = tempCalEnd ? tempCalEnd.getTime() : null;

            if (startT === cellTime || endT === cellTime) {
                dayCell.classList.add('selected');
            } else if (startT && endT && cellTime > startT && cellTime < endT) {
                dayCell.classList.add('in-range');
            }

            // Click interaction (Select start, then end, or reset)
            dayCell.addEventListener('click', function (e) {
                e.stopPropagation(); // <--- This is the magic line that stops it from closing

                if (!tempCalStart || (tempCalStart && tempCalEnd)) {
                    // Start a new selection
                    tempCalStart = cellDate;
                    tempCalEnd = null;
                } else if (tempCalStart && !tempCalEnd) {
                    // Complete the selection
                    if (cellTime < tempCalStart.getTime()) {
                        tempCalStart = cellDate; // If they click a date before the start date, make it the new start
                    } else {
                        tempCalEnd = cellDate;
                    }
                }
                renderCalendar();
            });

            calDays.appendChild(dayCell);
        }
    };

    const hideRangePopover = function () {
        if (!rangePopover || !customRangeBtn) return;
        rangePopover.hidden = true;
        customRangeBtn.setAttribute('aria-expanded', 'false');
    };

    const showRangePopover = function () {
        if (!rangePopover || !customRangeBtn) return;
        rangePopover.hidden = false;
        customRangeBtn.setAttribute('aria-expanded', 'true');

        // Setup initial viewing state
        tempCalStart = state.customStart ? new Date(state.customStart) : null;
        tempCalEnd = state.customEnd ? new Date(state.customEnd) : null;
        viewingDate = tempCalStart ? new Date(tempCalStart) : new Date();
        renderCalendar();
    };

    // Calendar Navigation Listeners
    if (calPrev) {
        calPrev.addEventListener('click', function (e) {
            e.stopPropagation();
            viewingDate.setMonth(viewingDate.getMonth() - 1);
            renderCalendar();
        });
    }
    if (calNext) {
        calNext.addEventListener('click', function (e) {
            e.stopPropagation();
            viewingDate.setMonth(viewingDate.getMonth() + 1);
            renderCalendar();
        });
    }

    // ===== Event Listeners =====
    cards.forEach(function (card) {
        card.addEventListener('click', () => openDrawer(card));
        card.addEventListener('keydown', (e) => {
            if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); openDrawer(card); }
        });
    });

    if (closeBtn) closeBtn.addEventListener('click', closeDrawer);
    if (overlay) overlay.addEventListener('click', closeDrawer);

    filterButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            const range = button.dataset.range || 'all';
            filterButtons.forEach(b => b.classList.remove('active'));
            button.classList.add('active');

            if (range !== 'custom') {
                hideRangePopover();
                state.range = range;
                applyFiltersAndSort();
            } else {
                rangePopover?.hidden ? showRangePopover() : hideRangePopover();
            }
        });
    });

    if (rangeCancel) {
        rangeCancel.addEventListener('click', function (e) {
            e.stopPropagation();
            hideRangePopover();
            // Fallback to "All orders" on cancel if a custom range wasn't already successfully active
            if (state.range !== 'custom') {
                filterButtons.forEach(b => b.classList.remove('active'));
                const allBtn = filterButtons.find(b => b.dataset.range === 'all');
                if (allBtn) allBtn.classList.add('active');
                state.range = 'all';
                applyFiltersAndSort();
            }
        });
    }

    if (rangeSubmit) {
        rangeSubmit.addEventListener('click', function (e) {
            e.stopPropagation();
            if (!tempCalStart) return;

            // Set start date to 00:00:00
            state.customStart = new Date(tempCalStart);
            state.customStart.setHours(0, 0, 0, 0);

            // Set end date to 23:59:59 of the selected end day
            if (tempCalEnd) {
                state.customEnd = new Date(tempCalEnd);
            } else {
                state.customEnd = new Date(tempCalStart); // If only 1 day selected
            }
            state.customEnd.setHours(23, 59, 59, 999);

            state.range = 'custom';

            hideRangePopover();
            applyFiltersAndSort();
        });
    }

    if (sortBtn) {
        sortBtn.addEventListener('click', function () {
            state.sort = state.sort === 'newest' ? 'oldest' : 'newest';
            sortBtn.dataset.sort = state.sort;
            const sortLabel = sortBtn.querySelector('.orders-action-label');
            if (sortLabel) sortLabel.textContent = state.sort === 'newest' ? 'Sort: Newest' : 'Sort: Oldest';
            applyFiltersAndSort();
        });
    }

    if (statusBtn) {
        const statuses = ['all', 'intransit', 'completed', 'processing', 'pending'];
        const labels = { all: 'All', intransit: 'In Transit', completed: 'Completed', processing: 'Processing', pending: 'Pending' };
        statusBtn.addEventListener('click', function () {
            state.status = statuses[(statuses.indexOf(state.status) + 1) % statuses.length];
            statusBtn.dataset.filter = state.status;
            const filterLabel = statusBtn.querySelector('.orders-action-label');
            if (filterLabel) filterLabel.textContent = `Filter: ${labels[state.status]}`;
            applyFiltersAndSort();
        });
    }

    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') { closeDrawer(); hideRangePopover(); }
    });

    document.addEventListener('click', function (e) {
        if (!rangePopover || rangePopover.hidden) return;
        if (rangePopover.contains(e.target) || customRangeBtn?.contains(e.target)) return;
        hideRangePopover();
    });

    // Run initial filter
    applyFiltersAndSort();
})();