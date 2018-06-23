window.sr = ScrollReveal();
sr.reveal('.showcase-top', {
    duration: 1000,
    origin:'top',
    distance:'100px',
    viewFactor: 0.2
});
sr.reveal('.showcase-left', {
    duration: 2000,
    origin:'left',
    distance:'150px'
});
sr.reveal('.showcase-right', {
    duration: 2000,
    origin: 'right',
    distance: '150px'
});
$(function() {
    // Smooth Scrolling
    $('a[href*="#"]:not([href="#"])').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });
});
