function addSidebar() {
    var sidebar = document.createElement('div');
    sidebar.className = 'sidebar';
    sidebar.innerHTML = `
      <!-- Sidebar content goes here -->
      <h2>Documentation</h2>
      <a href="index.html">Main Page</a>
      <ul>
          <li><a href="#overview">Overview</a></li>
          <li><a href="#usage">Usage</a></li>
          <li><a href="#examples">Examples</a></li>
      </ul>
      <a href="${getRelativePath('basics/basics1.html')}">Basics</a>
      <ul>
          <li><a href="#overview">Overview</a></li>
          <li><a href="#usage">Usage</a></li>
          <li><a href="#examples">Examples</a></li>
      </ul>
    `;

    // Append the sidebar to the body element
    document.body.appendChild(sidebar);

    // JavaScript to adjust the sidebar position while scrolling
    window.addEventListener('scroll', function () {
        var sidebar = document.querySelector('.sidebar');
        var content = document.querySelector('.content');
        var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        sidebar.style.top = Math.max(10, 10 - scrollTop) + 'px';
        content.style.marginTop = Math.max(0, 210 - scrollTop) + 'px';
    });
}

function getRelativePath(path) {
    var currentPath = window.location.pathname;
    var basePath = currentPath.substring(0, currentPath.lastIndexOf('/'));
    return basePath + '/' + path;
}
