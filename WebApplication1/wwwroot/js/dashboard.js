document.addEventListener('DOMContentLoaded', function () {
    // Theme Toggle
    const themeToggle = document.getElementById('theme-toggle');
    const body = document.body;

    // Check for saved theme preference or use preferred color scheme
    const savedTheme = localStorage.getItem('theme') ||
        (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light');

    if (savedTheme === 'dark') {
        body.classList.add('dark-mode');
        themeToggle.checked = true;
    }

    themeToggle.addEventListener('change', function () {
        if (this.checked) {
            body.classList.add('dark-mode');
            localStorage.setItem('theme', 'dark');
        } else {
            body.classList.remove('dark-mode');
            localStorage.setItem('theme', 'light');
        }
    });

    // Sample data for charts
    const salesData = {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul'],
        datasets: [{
            label: 'Sales',
            data: [12000, 19000, 15000, 18000, 22000, 25000, 28000],
            backgroundColor: 'rgba(115, 103, 240, 0.2)',
            borderColor: 'rgba(115, 103, 240, 1)',
            borderWidth: 2,
            tension: 0.4,
            fill: true
        }]
    };

    const trafficData = {
        labels: ['Direct', 'Referral', 'Social', 'Organic'],
        datasets: [{
            data: [35, 25, 20, 20],
            backgroundColor: [
                'rgba(115, 103, 240, 0.8)',
                'rgba(40, 199, 111, 0.8)',
                'rgba(255, 159, 67, 0.8)',
                'rgba(0, 207, 232, 0.8)'
            ],
            borderWidth: 0
        }]
    };

    // Initialize charts
    const salesChart = new Chart(
        document.getElementById('salesChart'),
        {
            type: 'line',
            data: salesData,
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Monthly Sales',
                        font: {
                            size: 16
                        }
                    }
                },
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: {
                            callback: function (value) {
                                return '$' + value.toLocaleString();
                            }
                        }
                    }
                }
            }
        }
    );

    const trafficChart = new Chart(
        document.getElementById('trafficChart'),
        {
            type: 'doughnut',
            data: trafficData,
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'right',
                    },
                    title: {
                        display: true,
                        text: 'Traffic Sources',
                        font: {
                            size: 16
                        }
                    }
                },
                cutout: '70%'
            }
        }
    );

    // Sample data for recent orders table
    //const orders = [
    //    { id: '#1234', customer: 'John Smith', date: '2023-05-15', amount: '$125.00', status: 'completed' },
    //    { id: '#1235', customer: 'Sarah Johnson', date: '2023-05-14', amount: '$89.50', status: 'pending' },
    //    { id: '#1236', customer: 'Michael Brown', date: '2023-05-14', amount: '$235.75', status: 'completed' },
    //    { id: '#1237', customer: 'Emily Davis', date: '2023-05-13', amount: '$65.20', status: 'completed' },
    //    { id: '#1238', customer: 'Robert Wilson', date: '2023-05-12', amount: '$154.00', status: 'failed' },
    //    { id: '#1239', customer: 'Jennifer Lee', date: '2023-05-11', amount: '$210.50', status: 'completed' },
    //    { id: '#1240', customer: 'David Miller', date: '2023-05-10', amount: '$99.99', status: 'pending' }
    //];

    // Populate orders table
    //const tableBody = document.querySelector('table tbody');

    //orders.forEach(order => {
    //    const row = document.createElement('tr');

    //    row.innerHTML = `
    //        <td>${order.id}</td>
    //        <td>${order.customer}</td>
    //        <td>${order.date}</td>
    //        <td>${order.amount}</td>
    //        <td><span class="status ${order.status}">${order.status.charAt(0).toUpperCase() + order.status.slice(1)}</span></td>
    //        <td><button class="action-btn">View</button></td>
    //    `;

    //    tableBody.appendChild(row);
    //});

    // Mobile menu toggle (for small screens)
    const menuToggle = document.createElement('button');
    menuToggle.className = 'menu-toggle';
    menuToggle.innerHTML = '☰';
    document.body.appendChild(menuToggle);

    menuToggle.addEventListener('click', function () {
        document.querySelector('.sidebar').classList.toggle('active');
    });

    // Close sidebar when clicking outside on mobile
    document.addEventListener('click', function (e) {
        if (window.innerWidth <= 576 &&
            !e.target.closest('.sidebar') &&
            !e.target.closest('.menu-toggle')) {
            document.querySelector('.sidebar').classList.remove('active');
        }
    });

    // Update charts when theme changes
    themeToggle.addEventListener('change', function () {
        salesChart.update();
        trafficChart.update();
    });
});