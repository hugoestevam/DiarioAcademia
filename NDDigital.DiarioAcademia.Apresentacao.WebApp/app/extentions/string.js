(function (angular) {

    String.prototype.contains = function (value) {
        return this.indexOf(value) >= 0;
    }

})(window.angular);