function toggleMenu(id, tipoDisplay) {
    let doc = document.getElementById(id);
    doc.style.display = doc.style.display != tipoDisplay ? tipoDisplay : 'none';
}

