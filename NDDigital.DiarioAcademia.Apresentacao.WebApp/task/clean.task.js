/*
 *
 * CLEAN TASKS
 *
 * gulp tasks cleaning the deploy
 *
 */

gulp.task('clean-dist', function (callback) {
    log('Cleaning: dist all files');
    del(config.dist.all, { force: true }, callback);
});

gulp.task('clean-js', function (callback) {
    log('Cleaning: dist js');
    del(config.dist.js, { force: true }, callback);
});

gulp.task('clean-css', function (callback) {
    log('Cleaning: dist css');
    del(config.dist.css, { force: true }, callback);
});

gulp.task('clean-html', function (callback) {
    log('Cleaning: dist html');
    del(config.dist.html, { force: true }, callback);
});