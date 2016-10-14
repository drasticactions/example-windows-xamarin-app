var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };

function preventDefault(e) {
	//if(window.event)
	//	window.external.notify(window.event);
	//window.external.notify(e);
	e = e || window.event;
	if (e.preventDefault)
		e.preventDefault();
	e.returnValue = false;
}

function preventDefaultForScrollKeys(e) {

	//window.external.notify(e.keyCode);

	if (keys[e.keyCode]) {
		preventDefault(e);
		return false;
	}
}

//function disableScroll() {
//	if (window.addEventListener) // older FF
//		window.addEventListener('DOMMouseScroll', preventDefault, false);
//	window.onwheel = preventDefault; // modern standard
//	window.onmousewheel = document.onmousewheel = preventDefault; // older browsers, IE
//	window.ontouchmove = preventDefault; // mobile
//	document.onkeydown = preventDefaultForScrollKeys;
//}

//function enableScroll() {
//	if (window.removeEventListener)
//		window.removeEventListener('DOMMouseScroll', preventDefault, false);
//	window.onmousewheel = document.onmousewheel = null;
//	window.onwheel = null;
//	window.ontouchmove = null;
//	document.onkeydown = null;
//}

function launchFullscreen() {
	$("body")[0].msRequestFullscreen();
}

function stopAllVideos() {
	$(".embed_video2").remove();
}


window.onbeforeunload = function (e) {
	var e = e || window.event;
	var msg = "Do you really want to leave this page?"

	// For IE and Firefox
	if (e) {
		e.returnValue = msg;
	}

	// For Safari / chrome
	return msg;
};

$(function () {

	//window.onwheel = function (e) {
	//	console.log(e.wheelDelta);
	//}
	//$(window).scroll(function (e) {

	//	//console.log("test");
	//	window.external.notify("hello!");

	//	if ($(window).scrollTop() + $(window).height() == $(document).height()) {
	//		disableScroll();
	//	}
	//});
});




$(function () {

	var calculatedHeight = $("body").innerWidth() / 1.6;
	if (calculatedHeight > 500)
		calculatedHeight = 500;
	$('.embed_video2').css({



		width: '100%',
		height: calculatedHeight + 'px'
	}), $(window).resize(function () {

		var calculatedHeight = $("body").innerWidth() / 1.6;
		if (calculatedHeight > 500)
			calculatedHeight = 500;

		$('.embed_video2').css({
			width: '100%',
			height: calculatedHeight + 'px'
		})
	})
});