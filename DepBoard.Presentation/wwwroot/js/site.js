// Sidebar: abre/fecha ao clicar no hamburger e lembra a escolha
(function () {
    const sidebar = document.getElementById('sidebar');
    const botao = document.getElementById('sidebar-toggle');
    if (!sidebar || !botao) return;

    const CHAVE = 'depboard.sidebar.colapsada';

    function aplicar(colapsada) {
        sidebar.dataset.collapsed = String(colapsada);
        botao.setAttribute('aria-expanded', String(!colapsada));
    }

    let colapsada = false;
    try { colapsada = localStorage.getItem(CHAVE) === '1'; } catch { }
    aplicar(colapsada);

    botao.addEventListener('click', function () {
        colapsada = sidebar.dataset.collapsed !== 'true';
        aplicar(colapsada);
        try { localStorage.setItem(CHAVE, colapsada ? '1' : '0'); } catch { }
    });
})();