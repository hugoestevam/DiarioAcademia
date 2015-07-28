(function (angular) {
    Array.prototype.indexOfObject = function (obj) {
        for (var i in this) {
            if (this[i].id == obj.id)
                return i;
        }
        return -1;
    };

    Array.prototype.remove = function (obj) {
        var index = this.indexOfObject(obj);
        if (index < 0)
            return false;
        this.splice(index, 1);
        return true;
    }

    Array.prototype.contains = function (obj) {
        // return this.indexOfObject(obj) >= 0; not works correcty
        return this.indexOf(obj) >= 0;
    }

})(window.angular);