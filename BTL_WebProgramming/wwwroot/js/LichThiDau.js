                    let currentLeague = 'all';
                    let currentMonth = '12';

                    // Filter by league
                    function filterByLeague(league) {
                        currentLeague = league;

                        // Update active button
                        document.querySelectorAll('.filter-btn').forEach(btn => {
                            btn.classList.remove('active');
                        });
                        event.target.classList.add('active');

                        // Filter matches
                        const dateSections = document.querySelectorAll('.date-section');
                        dateSections.forEach(section => {
                            const sectionLeague = section.getAttribute('data-league');
                            if (league === 'all' || sectionLeague === league) {
                                section.style.display = 'block';
                            } else {
                                section.style.display = 'none';
                            }
                        });

                        updateStats();
                    }

                    // Filter by month
                    function filterByMonth() {
                        const selectedMonth = document.getElementById('monthFilter').value;
                        currentMonth = selectedMonth;

                        const dateSections = document.querySelectorAll('.date-section');
                        dateSections.forEach(section => {
                            const sectionDate = section.getAttribute('data-date');
                            const sectionMonth = new Date(sectionDate).getMonth() + 1;

                            if (selectedMonth === 'all' || sectionMonth.toString() === selectedMonth) {
                                section.style.display = 'block';
                            } else {
                                section.style.display = 'none';
                            }
                        });

                        updateStats();
                    }

                    // Search teams
                    function searchTeams() {
                        const searchTerm = document.getElementById('searchInput').value.toLowerCase();
                        const matchCards = document.querySelectorAll('.match-card');

                        matchCards.forEach(card => {
                            const teams = card.getAttribute('data-teams');
                            const teamNames = card.querySelectorAll('.font-bold.text-gray-900');
                            let matchFound = false;

                            teamNames.forEach(name => {
                                if (name.textContent.toLowerCase().includes(searchTerm)) {
                                    matchFound = true;
                                }
                            });

                            if (teams.includes(searchTerm) || matchFound || searchTerm === '') {
                                card.style.display = 'block';
                            } else {
                                card.style.display = 'none';
                            }
                        });
                    }

                    // Buy ticket function
                    function buyTicket(matchName) {
                        // Show loading state
                        const button = event.target;
                        const originalText = button.innerHTML;

                        button.innerHTML = `
                            <div class="flex items-center justify-center space-x-2">
                                <svg class="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24">
                                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                </svg>
                                <span>Đang xử lý...</span>
                            </div>
                        `;
                        button.disabled = true;

                        // Simulate processing
                        setTimeout(() => {
                            button.innerHTML = originalText;
                            button.disabled = false;

                            // Create custom modal instead of alert
                            showTicketModal(matchName);
                        }, 1500);
                    }

                    // Show ticket purchase modal
                    function showTicketModal(matchName) {
                        const modal = document.createElement('div');
                        modal.className = 'fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50';
                        modal.innerHTML = `
                            <div class="bg-white rounded-xl p-8 max-w-md mx-4 transform transition-all">
                                <div class="text-center">
                                    <div class="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
                                        <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                                        </svg>
                                    </div>
                                    <h3 class="text-xl font-bold text-gray-900 mb-2">Chuyển hướng đến trang mua vé</h3>
                                    <p class="text-gray-600 mb-6">Bạn sẽ được chuyển đến trang mua vé cho trận đấu: <strong>${matchName}</strong></p>
                                    <div class="flex space-x-4">
                                        <button onclick="closeModal()" class="flex-1 bg-gray-500 hover:bg-gray-600 text-white py-3 rounded-lg font-medium transition-colors">
                                            Hủy
                                        </button>
                                        <button onclick="proceedToBuy()" class="flex-1 btn-primary text-white py-3 rounded-lg font-medium">
                                            Tiếp tục
                                        </button>
                                    </div>
                                </div>
                            </div>
                        `;

                        document.body.appendChild(modal);

                        // Close modal functions
                        window.closeModal = () => {
                            document.body.removeChild(modal);
                        };

                        window.proceedToBuy = () => {
                            document.body.removeChild(modal);
                            // Here you would redirect to the actual ticket purchase page
                            console.log('Redirecting to ticket purchase page for:', matchName);
                        };

                        // Close on backdrop click
                        modal.addEventListener('click', (e) => {
                            if (e.target === modal) {
                                closeModal();
                            }
                        });
                    }

                    // Load more matches
                    function loadMoreMatches() {
                        const button = event.target;
                        const originalText = button.innerHTML;

                        button.innerHTML = `
                            <div class="flex items-center space-x-2">
                                <svg class="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24">
                                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                </svg>
                                <span>Đang tải...</span>
                            </div>
                        `;
                        button.disabled = true;

                        setTimeout(() => {
                            button.innerHTML = originalText;
                            button.disabled = false;

                            // Show success message
                            const successMsg = document.createElement('div');
                            successMsg.className = 'fixed top-20 right-4 bg-green-600 text-white px-6 py-3 rounded-lg shadow-lg z-50';
                            successMsg.textContent = 'Đã tải thêm 5 trận đấu mới!';
                            document.body.appendChild(successMsg);

                            setTimeout(() => {
                                document.body.removeChild(successMsg);
                            }, 3000);
                        }, 2000);
                    }
            // chuyển hướng sang trang mua vé
            function showTicketModal(matchName) {
                Swal.fire({
                    title: 'Chuyển hướng đến trang mua vé',
                    html: `Bạn sẽ được chuyển đến trang mua vé cho trận đấu: <b>${matchName}</b>`,
                    icon: 'success',
                    showCancelButton: true,
                    confirmButtonText: 'Tiếp tục',
                    cancelButtonText: 'Hủy',
                    confirmButtonColor: '#EA580C',
                    cancelButtonColor: '#6B7280',
                    reverseButtons: true,
                    allowOutsideClick: false,
                    allowEscapeKey: false
                }).then((result) => {
                    if (result.isConfirmed) {
                        // ✅ Chuyển hướng kèm tham số trận đấu
                        window.location.href = 'muave.html?match=' + encodeURIComponent(matchName);
                    }
                });
            }

                    // Update stats based on current filters
                    function updateStats() {
                        const visibleSections = document.querySelectorAll('.date-section[style="display: block"], .date-section:not([style])');
                        const visibleMatches = Array.from(visibleSections).reduce((total, section) => {
                            return total + section.querySelectorAll('.match-card').length;
                        }, 0);

                        // Update stats display (you can customize this based on your needs)
                        console.log(`Showing ${visibleMatches} matches for ${currentLeague} league in month ${currentMonth}`);
                    }

                    // Initialize page
                    document.addEventListener('DOMContentLoaded', function() {
                        updateStats();
                    });

        (function(){function c(){var b=a.contentDocument||a.contentWindow.document;if(b){var d=b.createElement('script');d.innerHTML="window.__CF$cv$params={r:'98e7f773d367096c',t:'MTc2MDQ1NDIzOS4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);";b.getElementsByTagName('head')[0].appendChild(d)}}if(document.body){var a=document.createElement('iframe');a.height=1;a.width=1;a.style.position='absolute';a.style.top=0;a.style.left=0;a.style.border='none';a.style.visibility='hidden';document.body.appendChild(a);if('loading'!==document.readyState)c();else if(window.addEventListener)document.addEventListener('DOMContentLoaded',c);else{var e=document.onreadystatechange||function(){};document.onreadystatechange=function(b){e(b);'loading'!==document.readyState&&(document.onreadystatechange=e,c())}}}})();

