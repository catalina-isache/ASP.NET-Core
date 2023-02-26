const sidebarToggle = document.getElementById('sidebar-toggle');
const wrapper = document.getElementById('wrapper');

sidebarToggle.addEventListener('click', (event) => {
  event.preventDefault();
  wrapper.classList.toggle('toggled');
});
