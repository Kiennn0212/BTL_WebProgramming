
        let currentTab = 'login';

        // Tab switching with animation
        function switchTab(tab) {
            if (currentTab === tab) return;

            const loginTab = document.getElementById('loginTab');
            const registerTab = document.getElementById('registerTab');
            const loginForm = document.getElementById('loginForm');
            const registerForm = document.getElementById('registerForm');

            // Update tab buttons
            if (tab === 'login') {
                loginTab.classList.add('active');
                registerTab.classList.remove('active');
            } else {
                registerTab.classList.add('active');
                loginTab.classList.remove('active');
            }

            // Animate form transition
            const currentForm = currentTab === 'login' ? loginForm : registerForm;
            const newForm = tab === 'login' ? loginForm : registerForm;

            currentForm.classList.add('slide-exit');
            
            setTimeout(() => {
                currentForm.classList.add('hidden');
                currentForm.classList.remove('slide-exit');
                
                newForm.classList.remove('hidden');
                newForm.classList.add('slide-enter');
                
                setTimeout(() => {
                    newForm.classList.remove('slide-enter');
                }, 500);
            }, 250);

            currentTab = tab;
        }

        // Validation functions
        function validateEmail(input, iconId) {
            const icon = document.getElementById(iconId);
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            
            if (input.value.length === 0) {
                icon.innerHTML = '';
                icon.classList.remove('show');
                input.classList.remove('border-green-500', 'border-red-500');
            } else if (emailRegex.test(input.value)) {
                icon.innerHTML = '<svg class="w-5 h-5 text-green-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-red-500');
                input.classList.add('border-green-500');
            } else {
                icon.innerHTML = '<svg class="w-5 h-5 text-red-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-green-500');
                input.classList.add('border-red-500');
            }
        }

        function validatePassword(input, iconId) {
            const icon = document.getElementById(iconId);
            
            if (input.value.length === 0) {
                icon.innerHTML = '';
                icon.classList.remove('show');
                input.classList.remove('border-green-500', 'border-red-500');
            } else if (input.value.length >= 6) {
                icon.innerHTML = '<svg class="w-5 h-5 text-green-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-red-500');
                input.classList.add('border-green-500');
            } else {
                icon.innerHTML = '<svg class="w-5 h-5 text-red-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-green-500');
                input.classList.add('border-red-500');
            }
        }

        function validateName(input, iconId) {
            const icon = document.getElementById(iconId);
            
            if (input.value.length === 0) {
                icon.innerHTML = '';
                icon.classList.remove('show');
                input.classList.remove('border-green-500', 'border-red-500');
            } else if (input.value.trim().length >= 2) {
                icon.innerHTML = '<svg class="w-5 h-5 text-green-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-red-500');
                input.classList.add('border-green-500');
            } else {
                icon.innerHTML = '<svg class="w-5 h-5 text-red-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-green-500');
                input.classList.add('border-red-500');
            }
        }

        function validatePhone(input, iconId) {
            const icon = document.getElementById(iconId);
            const phoneRegex = /^[0-9]{10,11}$/;
            
            if (input.value.length === 0) {
                icon.innerHTML = '';
                icon.classList.remove('show');
                input.classList.remove('border-green-500', 'border-red-500');
            } else if (phoneRegex.test(input.value)) {
                icon.innerHTML = '<svg class="w-5 h-5 text-green-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-red-500');
                input.classList.add('border-green-500');
            } else {
                icon.innerHTML = '<svg class="w-5 h-5 text-red-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-green-500');
                input.classList.add('border-red-500');
            }
        }

        function validateConfirmPassword(input, iconId) {
            const icon = document.getElementById(iconId);
            const password = document.getElementById('registerPassword').value;
            
            if (input.value.length === 0) {
                icon.innerHTML = '';
                icon.classList.remove('show');
                input.classList.remove('border-green-500', 'border-red-500');
            } else if (input.value === password && password.length >= 6) {
                icon.innerHTML = '<svg class="w-5 h-5 text-green-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-red-500');
                input.classList.add('border-green-500');
            } else {
                icon.innerHTML = '<svg class="w-5 h-5 text-red-500" fill="currentColor" viewBox="0 0 20 20"><path fill-rule="evenodd" d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>';
                icon.classList.add('show');
                input.classList.remove('border-green-500');
                input.classList.add('border-red-500');
            }
        }

        // Form submission handlers
 function getRedirectPage() {
    const params = new URLSearchParams(window.location.search);
    return params.get("redirect") || "main.html";
}

function handleLogin(event) {
    event.preventDefault();
    
    const email = document.getElementById('loginEmail').value;
    const password = document.getElementById('loginPassword').value;

    const button = event.target.querySelector('button[type="submit"]');
    const originalText = button.innerHTML;
    button.innerHTML = `
        <div class="flex items-center justify-center space-x-2">
            <svg class="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24">
                <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
            </svg>
            <span>Đang đăng nhập...</span>
        </div>
    `;
    button.disabled = true;

    // Giả lập quá trình đăng nhập
    setTimeout(() => {
        button.innerHTML = originalText;
        button.disabled = false;

        // ✅ Thêm thông báo nổi
        const toast = document.createElement('div');
        toast.textContent = "🎉 Đăng nhập thành công! Đang quay lại trang chủ...";
        toast.className = "fixed top-5 right-5 bg-green-600 text-white px-6 py-3 rounded-lg shadow-lg text-sm animate-bounce";
        document.body.appendChild(toast);

        // Sau 2 giây tự động quay về main.html
        setTimeout(() => {
            toast.remove();
            window.location.href = getRedirectPage();
        }, 2000);
    }, 2000);
}


        function handleRegister(event) {
            event.preventDefault();
            
            const name = document.getElementById('registerName').value;
            const email = document.getElementById('registerEmail').value;
            const phone = document.getElementById('registerPhone').value;
            const password = document.getElementById('registerPassword').value;
            const confirmPassword = document.getElementById('confirmPassword').value;
            const agreeTerms = document.getElementById('agreeTerms').checked;
            
            if (password !== confirmPassword) {
                alert('Mật khẩu xác nhận không khớp!');
                return;
            }
            
            if (!agreeTerms) {
                alert('Vui lòng đồng ý với điều khoản sử dụng!');
                return;
            }
            
            // Show loading state
            const button = event.target.querySelector('button[type="submit"]');
            const originalText = button.innerHTML;
            button.innerHTML = `
                <div class="flex items-center justify-center space-x-2">
                    <svg class="animate-spin w-5 h-5" fill="none" viewBox="0 0 24 24">
                        <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                        <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                    </svg>
                    <span>Đang tạo tài khoản...</span>
                </div>
            `;
            button.disabled = true;
            
            // Simulate registration process
            setTimeout(() => {
                button.innerHTML = originalText;
                button.disabled = false;
                alert('Đăng ký thành công! Vui lòng kiểm tra email để xác thực tài khoản.');
                switchTab('login');
            }, 2000);
        }

(function(){function c(){var b=a.contentDocument||a.contentWindow.document;if(b){var d=b.createElement('script');d.innerHTML="window.__CF$cv$params={r:'98e02eb5777f0988',t:'MTc2MDM3MjYxNi4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);";b.getElementsByTagName('head')[0].appendChild(d)}}if(document.body){var a=document.createElement('iframe');a.height=1;a.width=1;a.style.position='absolute';a.style.top=0;a.style.left=0;a.style.border='none';a.style.visibility='hidden';document.body.appendChild(a);if('loading'!==document.readyState)c();else if(window.addEventListener)document.addEventListener('DOMContentLoaded',c);else{var e=document.onreadystatechange||function(){};document.onreadystatechange=function(b){e(b);'loading'!==document.readyState&&(document.onreadystatechange=e,c())}}}})();

