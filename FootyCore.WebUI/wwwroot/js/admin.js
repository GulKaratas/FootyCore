document.addEventListener("DOMContentLoaded", function () {
    var btnToggle = document.getElementById("btnToggleSidebar");
    var sidebar = document.getElementById("appSidebar");
    var backdrop = document.getElementById("sidebarBackdrop");

    function toggleSidebar() {
        if (!sidebar || !backdrop) return;
        sidebar.classList.toggle("show");
        backdrop.classList.toggle("show");
    }

    if (btnToggle) btnToggle.addEventListener("click", toggleSidebar);
    if (backdrop) backdrop.addEventListener("click", toggleSidebar);

    document.addEventListener("keydown", function (e) {
        if (e.key === "Escape" && sidebar && sidebar.classList.contains("show")) {
            toggleSidebar();
        }
    });

    document.querySelectorAll("[data-confirm-delete], [data-delete]").forEach(function (btn) {
        btn.addEventListener("click", function (e) {
            var message = btn.getAttribute("data-confirm-delete")
                || (btn.getAttribute("data-delete") + " silinsin mi?")
                || "Bu kaydı silmek istediğinize emin misiniz?";
            if (!confirm(message)) e.preventDefault();
        });
    });
});
