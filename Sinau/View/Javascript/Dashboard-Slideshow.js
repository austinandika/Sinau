// SLIDESHOW
var slideIndex = 1;
var timer = null;
var slides = document.getElementsByClassName("slide");
var numberOfSlides = slides.length;

for (i = 0; i < numberOfSlides; i++) {
    $('.dot-container').append("<span class='slideshow-dot' onclick='currentSlide(" + (i + 1) + ")'></span>")
}

showSlides(slideIndex);

function plusSlides(n) {
    clearTimeout(timer);
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    clearTimeout(timer);
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("info-image-container");
    var dots = document.getElementsByClassName("slideshow-dot");
    if (n == undefined) { n = ++slideIndex }
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
    timer = setTimeout(showSlides, 5000);   // Change image every 5 seconds
} 