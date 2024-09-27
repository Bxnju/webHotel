let prevScrollpos = window.pageYOffset;

window.onscroll = function () {

    const currentScrollPos = window.pageYOffset;
    const navbar = document.querySelector('.navbar');

    if (prevScrollpos > currentScrollPos) {

        navbar.classList.add('visible');

    } else if (prevScrollpos > 300) {

        navbar.classList.remove('visible');

    }

    prevScrollpos = currentScrollPos;

};

const parallax = document.querySelector(".main_index");

window.addEventListener("scroll", () => {

    let offset = window.pageYOffset;
    parallax.style.backgroundPositionY = 100 - offset * 0.1 + "%";

});
