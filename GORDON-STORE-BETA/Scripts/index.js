// SCRIPT CARROSSEL]
    //Slider nav with arrows
	let sliderWrapper = document.querySelector(".sliderWrapper");
	let slider = document.querySelector(".slider");
	let navSliderButtons = document.querySelectorAll(".navSlider");
	let sliderSlides = document.querySelectorAll(".lien");
	let listeLien = document.querySelector(".listeLien");
	let sliderWidth = listeLien.offsetWidth;
	let slideAmount = sliderSlides.length;
	let slideWidth = sliderSlides[0].offsetWidth;
	let trueSliderWidth = slideAmount * slideWidth;
	let screenWidth = window.innerWidth;
	let sliderMarksWrapper = document.querySelector(".sliderMarks");

	let supportsNativeSmoothScroll = 'scrollBehavior' in document.documentElement.style;


	for (let i = 0; i < slideAmount; i++) {
		sliderMarksWrapper.innerHTML += "<div></div>";
	}

	let sliderMarks = sliderMarksWrapper.querySelectorAll(".sliderMarks div");


	if (trueSliderWidth >= screenWidth) {
		sliderWrapper.classList.add("overflowSlider");
	}

	for (let i = 0; i < navSliderButtons.length; i++) {
		let nav = navSliderButtons[i];
		let isRight = nav.classList.contains("navSliderRight");


		nav.addEventListener("click", function() {
			let currentScroll = slider.scrollLeft;
			let nearestSlide = Math.floor(currentScroll / slideWidth);
			let posTargetOffset = 0;
			let scrollLeftpx = 0;


			if (isRight) {
				posTargetOffset = 1;
			} else {
				if (
					currentScroll % slideWidth == 0 ||
					slideWidth % currentScroll == 0
				)
					posTargetOffset = -1;
			}

			scrollLeftpx = (nearestSlide + posTargetOffset) * slideWidth;
			if (supportsNativeSmoothScroll) {
				slider.scrollTo(scrollLeftpx, 300);
			} else {
				scrollTo_poly(slider, scrollLeftpx, 300);
			}
		});
	}


	// Detect slider scroll
	// Display or not arrows and gradient
	// Update slider points

	

	slider.addEventListener('scroll', function() {
		let distanceToRight = (trueSliderWidth - screenWidth - (sliderWidth - screenWidth) / 2) - this.scrollLeft;
		let currentSlide = Math.floor((this.scrollLeft + screenWidth / 2) / slideWidth);

		for (let i = 0; i < sliderMarks.length; i++) {
			sliderMarks[i].classList[(i != currentSlide ? "remove" : "add")]("active");
		}

		sliderWrapper.classList[(this.scrollLeft == 0 ? "add" : "remove")]("leftLocked");
		sliderWrapper.classList[(distanceToRight <= 1 ? "add" : "remove")]("rightLocked");

		console.log(distanceToRight);

	});

	window.addEventListener('resize', function() {
		slider = document.querySelector(".slider");
		slideAmount = sliderSlides.length;
		slideWidth = sliderSlides[0].offsetWidth;
		trueSliderWidth = slideAmount * slideWidth;
		screenWidth = window.innerWidth;

		if (trueSliderWidth >= screenWidth) {
			sliderWrapper.classList.add("overflowSlider");
		}
	});



	function scrollTo_poly(element, to = 0, duration = 1000, scrollToDone = null) {
		const start = element.scrollLeft;
		const change = to - start;
		const increment = 20;
		let currentTime = 0;

		const animateScroll = (() => {

			currentTime += increment;

			const val = Math.easeInOutQuad(currentTime, start, change, duration);

			element.scrollLeft = val;

			if (currentTime < duration) {
				setTimeout(animateScroll, increment);
			} else {
				if (scrollToDone) scrollToDone();
			}
		});

		animateScroll();
	};

	Math.easeInOutQuad = function(t, b, c, d) {

		t /= d / 2;
		if (t < 1) return c / 2 * t * t + b;
		t--;
		return -c / 2 * (t * (t - 2) - 1) + b;
	};
// SCRIPT CARROSSEL


function abrir(PopUp){
	if(document.getElementById(PopUp).style.display == 'block')
	document.getElementById(PopUp).style.display = 'none';
else{
	document.getElementById("PopUpSearch").style.display = 'none'; 
	document.getElementById("PopUpCart").style.display = 'none'; 
	document.getElementById("PopUpUsuario").style.display = 'none'; 
	document.getElementById(PopUp).style.display = 'block'; }
}
