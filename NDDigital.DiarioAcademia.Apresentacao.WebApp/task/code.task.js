/*
 *  
 * CODE TASKS 
 * 
 * gulp tasks handling source code
 * 
 */

gulp.task('inject', 'Inject the files in the index.html', ['inject-lib', 'templatecache'], function (callback) {
    var resources = config.getResourcesInjected();
    var source = gulp.src(config.index);
    for (var resource in resources) {
        source = source.pipe(loader.inject(gulp.src(resources[resource]), {
            starttag: "<!--inject:" + resource + "-->"
        }));
    }
    source.pipe(gulp.dest(config.root)).on('end', callback);;
});


gulp.task('inject-lib',  'Inject only libs in the index.html', function (callback) {
    var wiredep = require('wiredep').stream;
    var options = config.getWiredepDefaultOptions();

    gulp.src(config.index)
          .pipe(wiredep(options))
          .pipe(loader.inject(gulp.src(config.libs.css)))
          .pipe(gulp.dest(config.root).on('end', callback));
});


gulp.task('build-optimized', 'Build of application optimized', ['inject', 'build-optimized-resources'], function () {
    var builder = loader.useref.assets({ searchPath: "./" });
    var cssFilter = loader.filter('**/*.css', { restore: true });
    var jsAppFilter = loader.filter('**/app.js', { restore: true });
    var jsLibsFilter = loader.filter('**/libs.js', { restore: true });
    return gulp.src(config.index)
              .pipe(builder) //verify the tags 'build' and generate the builds
              //css
              .pipe(cssFilter)
              .pipe(loader.csso()) // css optimize
              .pipe(cssFilter.restore)
              //libs js
              .pipe(jsLibsFilter)
              .pipe(loader.ngAnnotate()) // $inject
              .pipe(loader.uglify()) // minify
              .pipe(jsLibsFilter.restore)
              //app js
              .pipe(jsAppFilter)
              .pipe(loader.ngAnnotate()) // $inject
              .pipe(loader.uglify()) // minify
              .pipe(jsAppFilter.restore)
              .pipe(builder.restore())
              .pipe(loader.useref())  // define build in index
              .pipe(gulp.dest(config.dist.root));
});


gulp.task('build-optimized-resources', 'Publish of resources used by application', function (done) {
    //fonts
    gulp.src(config.fonts)
                .pipe(gulp.dest(config.dist.font));
    //views
    gulp.src(config.app.html)
                .pipe(loader.minifyHtml({
                    conditionals: true
                }))
                .pipe(gulp.dest(config.dist.app));
    //images
    gulp.src(config.app.images)
                .pipe(loader.imagemin({
                    progressive: true, //jpg
                    interlaced: true, //gif
                    optipng: true, // png
                    optmizationLevel: 7  // 0 - 7
                }))
                .pipe(gulp.dest(config.dist.app).on('end', done));
});

gulp.task('templatecache', 'Generate template cache', function () {
    gulp.src(config.app.html)
         .pipe(loader.minifyHtml({
             empty: true,
             conditionals: true
         }))
         .pipe(loader.angularTemplatecache(config.templatecache.file, config.templatecache.options))
         .pipe(gulp.dest(config.templatecache.path));
});