/*
 *
 * CLEAN TASKS
 *
 * gulp tasks cleaning the deploy
 *
 */

gulp.task('clean-dist','Clean the paste dist' ,function (callback) {
    del(config.dist, { force: true }, callback);
});

gulp.task('clean-css', 'Clean all css of paste css', function (callback) {
    del(config.app.distCss, { force: true }, callback);
});

