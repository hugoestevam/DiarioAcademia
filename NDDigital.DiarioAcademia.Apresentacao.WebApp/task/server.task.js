/*
 *
 * SERVER TASKS
 *
 * gulp tasks starting the application
 *
 */

gulp.task('start', 'Start dev app.--livereload: use livereload', ['inject'], function () {
    var browserSync = require('browser-sync');
    var options = config.getBrowsersyncOptionsDefault();
    if (yargs.livereload)
        browserSync(options);
    else {
        gulp.src(config.index)
        .pipe(open({
            uri: "http:\\localhost:" + config.port,
            app: 'Chrome'
        }));
    }
    connect.server({
        root: [config.path], // do not use './'
        port: config.port,
    });
});

gulp.task('start-app', 'Start publish version of app optimized', ['build-optimized'], function () {
    var open = require('gulp-open');
    //start application
    connect.server({
        root: ['dist'],
        port: config.port,
    });
    //open application
    gulp.src(config.index)
          .pipe(open({
              uri: "http:\\localhost:" + config.port,
              app: 'Chrome'
          }));
});
