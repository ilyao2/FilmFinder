var elements = document.getElementsByClassName('cardWrepper');

for (i = 0; i < elements.length; i++){
	elements[i].onmouseenter = overEvent;
	elements[i].onmouseleave = outEvent;
	elements[i].onmousemove = moveEvent;
}

Height = elements[0].offsetHeight;
Width = elements[0].offsetWidth;

function overEvent(e) {
	element = e.currentTarget;
	over(element);
}

function over(element){
	var start = Date.now(); // запомнить время начала

	var timer = setInterval(function() {
	// сколько времени прошло с начала анимации?
	var timePassed = Date.now() - start;

	if (timePassed >= 200) {
		clearInterval(timer);
	}

	progress = timePassed/200
	element.style.width = (Width * (1 + progress * 0.25) + 'px');
	element.style.height = (Height * (1 + progress * 0.25) + 'px');

	}, 10);

}

function outEvent(e) {
	element = e.currentTarget;
	out(element);
}

function out(element){

  	element.children[0].style.filter = 'brightness(1)';
	element.children[0].style.transform = 'rotateX(' + 0 + 'deg)' + ' rotateY(' + 0 + 'deg)';
	element.children[0].style.boxShadow = 10 + 'px ' + 10 + 'px 10px #000';
	var start = Date.now(); // запомнить время начала
	var timer = setInterval(function() {
	// сколько времени прошло с начала анимации?
	var timePassed = Date.now() - start;

	if (timePassed > 200) {
		clearInterval(timer);
		element.style.width = Width;
		element.style.height = Height;
		return;
	}

	progress = timePassed / 200;
	element.style.width = (Width * (1 + (1 - progress) * 0.25) + 'px');
	element.style.height = (Height * (1 + (1 - progress) * 0.25) + 'px');

	}, 10);
}

function moveEvent(e) {
	element = e.currentTarget.children[0];
	var x = event.pageX - e.currentTarget.offsetLeft;
	var y = event.pageY - e.currentTarget.offsetTop;
	nY = y / e.currentTarget.offsetHeight/1.5;
	nX = x / e.currentTarget.offsetWidth/1.5;


	brightness = 2 - nY * 2;
	degX = 0.0;
	degY = 0.0;
	deg = 70;
	if(nY > 0.5){
		degX = (nY - 0.5) * deg;
	}
	else{
		degX = -(0.5 - nY) * deg;
	}

	if(nX > 0.5){
		degY = -(nX - 0.5) * deg;
	}
	else{
		degY = (0.5 - nX) * deg;
	}

	shadowY = (1 - nY) * 30;
	shadowX = (1 - nX) * 30;

	element.style.filter = 'brightness(' + brightness + ')';
  //rotate3d(x, y, z, angle)
	element.style.transform = 'rotateX(' + degX + 'deg)' + ' rotateY(' + degY + 'deg)';
  //element.style.transform = 'rotate3d(0,1,0,' + degY +'deg) rotate3d(1,0,0,' + degX +'deg)'
	element.style.boxShadow = shadowX + 'px ' + shadowY + 'px 10px #000';
}





