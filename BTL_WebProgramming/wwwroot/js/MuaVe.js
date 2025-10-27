            let selectedTickets = [];
            let selectedSeats = [];

            function selectTicket(type) {
                // Remove previous selections
                document.querySelectorAll('.ticket-card').forEach(card => {
                    card.classList.remove('selected');
                });

                // Add selection to clicked card
                event.currentTarget.classList.add('selected');

                // Update selected ticket info
                const ticketInfo = {
                    'vip': { name: 'VIP', price: 2500000 },
                    'standard': { name: 'Standard', price: 1200000 },
                    'tribune-a': { name: 'Khán đài A', price: 800000 },
                    'tribune-b': { name: 'Khán đài B', price: 600000 }
                };

                selectedTickets = [{
                    type: type,
                    name: ticketInfo[type].name,
                    price: ticketInfo[type].price,
                    quantity: 1
                }];

                updateOrderSummary();
            }

            function toggleSeat(seatElement) {
                if (seatElement.classList.contains('occupied')) {
                    return;
                }

                if (seatElement.classList.contains('selected')) {
                    seatElement.classList.remove('selected');
                    const index = selectedSeats.indexOf(seatElement);
                    if (index > -1) {
                        selectedSeats.splice(index, 1);
                    }
                } else {
                    seatElement.classList.add('selected');
                    selectedSeats.push(seatElement);
                }

                updateOrderSummary();
            }
        // Lấy giá trị "match" từ URL
        const urlParams = new URLSearchParams(window.location.search);
        const matchName = urlParams.get('match');

        if (matchName) {
            // Hiển thị vào phần thông tin đặt vé
            const matchInfoElement = document.querySelector('.font-medium'); // Hoặc chọn đúng ID/class bạn dùng
            const titleElement = document.querySelector('h1');

            // Nếu tiêu đề đang hiển thị "MU vs Liverpool" thì thay bằng matchName
            if (titleElement && titleElement.textContent.includes('Premier League')) {
                const vsText = titleElement.previousElementSibling;
            }

            // Thay tên trận trong khung thông tin
            document.querySelectorAll('span.font-medium').forEach(el => {
                if (el.textContent.includes('MU vs Liverpool')) {
                    el.textContent = matchName;
                }
            });

            // Nếu có tiêu đề lớn “MU vs LIV” — tùy bạn đặt phần đó thế nào, ví dụ:
            document.querySelectorAll('.text-4xl.font-bold.text-yellow-400, .text-center h3')
        }
            function updateOrderSummary() {
                const selectedTicketsDiv = document.getElementById('selectedTickets');
                const totalPriceSpan = document.getElementById('totalPrice');
                const buyButton = document.getElementById('buyButton');

                if (selectedTickets.length === 0) {
                    selectedTicketsDiv.innerHTML = '<p class="text-gray-500 text-center py-4">Chưa chọn vé nào</p>';
                    totalPriceSpan.textContent = '0₫';
                    buyButton.disabled = true;
                    buyButton.classList.add('opacity-50', 'cursor-not-allowed');
                    return;
                }

                let html = '';
                let total = 0;

                selectedTickets.forEach(ticket => {
                    const subtotal = ticket.price * ticket.quantity;
                    total += subtotal;

                    html += `
                        <div class="flex justify-between items-center">
                            <div>
                                <div class="font-medium">${ticket.name}</div>
                                <div class="text-sm text-gray-500">Số lượng: ${ticket.quantity}</div>
                            </div>
                            <div class="text-right">
                                <div class="font-medium">${subtotal.toLocaleString()}₫</div>
                            </div>
                        </div>
                    `;
                });

                if (selectedSeats.length > 0) {
                    html += `
                        <div class="text-sm text-gray-600 mt-2">
                            Đã chọn ${selectedSeats.length} ghế ngồi
                        </div>
                    `;
                }

                selectedTicketsDiv.innerHTML = html;
                totalPriceSpan.textContent = total.toLocaleString() + '₫';

                buyButton.disabled = false;
                buyButton.classList.remove('opacity-50', 'cursor-not-allowed');
            }

            // Buy button click handler
            document.getElementById('buyButton').addEventListener('click', function() {
                if (selectedTickets.length === 0) return;

                alert(`Đặt vé thành công!\nTổng tiền: ${document.getElementById('totalPrice').textContent}\nVé sẽ được gửi qua email trong vòng 5 phút.`);
            });
(function () { function c() { var b = a.contentDocument || a.contentWindow.document; if (b) { var d = b.createElement('script'); d.innerHTML = "window.__CF$cv$params={r:'98dffa47951f09bc',t:'MTc2MDM3MDQ2OS4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);"; b.getElementsByTagName('head')[0].appendChild(d) } } if (document.body) { var a = document.createElement('iframe'); a.height = 1; a.width = 1; a.style.position = 'absolute'; a.style.top = 0; a.style.left = 0; a.style.border = 'none'; a.style.visibility = 'hidden'; document.body.appendChild(a); if ('loading' !== document.readyState) c(); else if (window.addEventListener) document.addEventListener('DOMContentLoaded', c); else { var e = document.onreadystatechange || function () { }; document.onreadystatechange = function (b) { e(b); 'loading' !== document.readyState && (document.onreadystatechange = e, c()) } } } })();
