         // Character counter for message textarea
            document.getElementById('message').addEventListener('input', function() {
                const maxLength = 500;
                const currentLength = this.value.length;
                document.getElementById('charCount').textContent = currentLength;

                if (currentLength > maxLength) {
                    this.value = this.value.substring(0, maxLength);
                    document.getElementById('charCount').textContent = maxLength;
                }
            });

            // Form submission
            function submitForm(event) {
                event.preventDefault();

                const submitBtn = document.getElementById('submitBtn');
                const originalText = submitBtn.innerHTML;

                // Show loading state
                submitBtn.innerHTML = `
                    <div class="flex items-center justify-center space-x-2">
                        <svg class="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24">
                            <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                            <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                        </svg>
                        <span>Đang gửi...</span>
                    </div>
                `;
                submitBtn.disabled = true;

                // Simulate form submission
                setTimeout(() => {
                    submitBtn.innerHTML = originalText;
                    submitBtn.disabled = false;

                    // Show success message
                    showSuccessMessage();

                    // Reset form
                    document.getElementById('contactForm').reset();
                    document.getElementById('charCount').textContent = '0';
                }, 2000);
            }

            // Show success message
            function showSuccessMessage() {
                const successModal = document.createElement('div');
                successModal.className = 'fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50';
                successModal.innerHTML = `
                    <div class="bg-white rounded-2xl p-8 max-w-md mx-4 text-center success-animation">
                        <div class="w-20 h-20 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-6">
                            <svg class="w-10 h-10 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"></path>
                            </svg>
                        </div>
                        <h3 class="text-2xl font-bold text-gray-900 mb-4">Gửi thành công!</h3>
                        <p class="text-gray-600 mb-6">
                            Cảm ơn bạn đã liên hệ với TicketBall. Chúng tôi sẽ phản hồi trong vòng 2 giờ làm việc.
                        </p>
                        <button onclick="closeSuccessModal()" class="btn-primary text-white px-8 py-3 rounded-lg font-medium">
                            Đóng
                        </button>
                    </div>
                `;

                document.body.appendChild(successModal);

                window.closeSuccessModal = () => {
                    document.body.removeChild(successModal);
                };
            }

            // FAQ Toggle
            function toggleFAQ(index) {
                const content = document.getElementById(`faq-content-${index}`);
                const icon = document.getElementById(`faq-icon-${index}`);

                if (content.classList.contains('hidden')) {
                    content.classList.remove('hidden');
                    icon.style.transform = 'rotate(180deg)';
                } else {
                    content.classList.add('hidden');
                    icon.style.transform = 'rotate(0deg)';
                }
            }

            // Contact actions
            function callHotline() {
                // Create call confirmation modal
                const modal = document.createElement('div');
                modal.className = 'fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50';
                modal.innerHTML = `
                    <div class="bg-white rounded-2xl p-8 max-w-md mx-4 text-center">
                        <div class="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
                            <svg class="w-8 h-8 text-green-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z"></path>
                            </svg>
                        </div>
                        <h3 class="text-xl font-bold text-gray-900 mb-2">Gọi hotline</h3>
                        <p class="text-gray-600 mb-6">Bạn có muốn gọi đến số hotline <strong>1900 1234</strong>?</p>
                        <div class="flex space-x-4">
                            <button onclick="closeModal()" class="flex-1 bg-gray-500 hover:bg-gray-600 text-white py-3 rounded-lg font-medium transition-colors">
                                Hủy
                            </button>
                            <button onclick="makeCall()" class="flex-1 bg-green-500 hover:bg-green-600 text-white py-3 rounded-lg font-medium transition-colors">
                                Gọi ngay
                            </button>
                        </div>
                    </div>
                `;

                document.body.appendChild(modal);

                window.closeModal = () => {
                    document.body.removeChild(modal);
                };

                window.makeCall = () => {
                    window.open('tel:19001234', '_self');
                    closeModal();
                };
            }

            function sendEmail() {
                window.open('mailto:support@ticketball.vn?subject=Hỗ trợ khách hàng&body=Xin chào TicketBall,%0D%0A%0D%0ATôi cần hỗ trợ về:', '_blank');
            }

            function viewMap() {
                document.querySelector('.map-container').scrollIntoView({
                    behavior: 'smooth',
                    block: 'center'
                });
            }
        
        (function(){function c(){var b=a.contentDocument||a.contentWindow.document;if(b){var d=b.createElement('script');d.innerHTML="window.__CF$cv$params={r:'98e84cd5d66504dc',t:'MTc2MDQ1NzczNy4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);";b.getElementsByTagName('head')[0].appendChild(d)}}if(document.body){var a=document.createElement('iframe');a.height=1;a.width=1;a.style.position='absolute';a.style.top=0;a.style.left=0;a.style.border='none';a.style.visibility='hidden';document.body.appendChild(a);if('loading'!==document.readyState)c();else if(window.addEventListener)document.addEventListener('DOMContentLoaded',c);else{var e=document.onreadystatechange||function(){};document.onreadystatechange=function(b){e(b);'loading'!==document.readyState&&(document.onreadystatechange=e,c())}}}})();

