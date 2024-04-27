document.querySelectorAll('.rotatable').forEach(function (element) {
    element.addEventListener('click', function () {
        this.querySelector('.img-arrow-white').classList.toggle('rotated');
    });
});