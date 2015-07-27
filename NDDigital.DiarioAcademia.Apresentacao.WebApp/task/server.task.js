/*
 *
 * SERVER TASKS
 *
 * gulp tasks starting the application
 *
 */

gulp.task('server-dev', ['inject'], function () {
    var browserSync = require('browser-sync');
    var options = config.getBrowsersyncOptionsDefault();
    connect.server({
        root: [config.path], // não usar './'
        port: config.port,
    });
    if (yargs.livereload)
        browserSync(options);
});

gulp.task('server-dist', ['optimize'], function () {
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

// start tasks
gulp.task('start', ['server-dev']);
gulp.task('start-app', ['server-dist']);