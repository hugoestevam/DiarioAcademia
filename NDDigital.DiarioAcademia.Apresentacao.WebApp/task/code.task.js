/*
 *  
 * CODE TASKS 
 * 
 * gulp tasks handling source code
 * 
 */

gulp.task('inject', ['inject-lib', 'templatecache'], function (callback) {
    var resources = config.getResourcesInjected();
    var source = gulp.src(config.index);
    for (var resource in resources) {
        source = source.pipe(loader.inject(gulp.src(resources[resource]), {
            starttag: "<!--inject:" + resource + "-->"
        }));
    }
    source.pipe(gulp.dest(config.root)).on('end', callback);;
});

gulp.task('templatecache', function () {
    gulp.src(config.app.html)
         .pipe(loader.minifyHtml({
             empty: true,
             conditionals: true
         }))
         .pipe(loader.angularTemplatecache(config.templatecache.file, config.templatecache.options))
         .pipe(gulp.dest(config.templatecache.path));
});

// 3rd party libraries 
gulp.task('inject-lib', function (callback) {
    var wiredep = require('wiredep').stream;
    var options = config.getWiredepDefaultOptions();

    gulp.src(config.index)
          .pipe(wiredep(options))
          .pipe(loader.inject(gulp.src(config.libs.css)))
          .pipe(gulp.dest(config.root).on('end', callback));
});


// Optimize css/html/js and generate file concatenated
gulp.task('optimize', ['inject', 'deploy-fonts', 'deploy-views', 'deploy-images'], function () {
    var builder = loader.useref.assets({ searchPath: "./" });
    var cssFilter = loader.filter('**/*.css');
    var jsAppFilter = loader.filter('**/app.js');
    var jsLibsFilter = loader.filter('**/libs.js');
    return gulp.src(config.index)
              .pipe(builder) //verify the tags 'build' and generate the builds
              //css
              .pipe(cssFilter)
              .pipe(loader.csso()) // css optimize
              .pipe(cssFilter.restore())
              //libs js
              .pipe(jsLibsFilter)
              .pipe(loader.ngAnnotate()) // $inject
              .pipe(loader.uglify()) // minify
              .pipe(jsLibsFilter.restore())
              //app js
              .pipe(jsAppFilter)
              .pipe(loader.ngAnnotate()) // $inject
              .pipe(loader.uglify()) // minify
              .pipe(jsAppFilter.restore())
              .pipe(builder.restore())
              .pipe(loader.useref())  // define build in index
              .pipe(gulp.dest(config.dist.root));
});

//Deploy Resources
gulp.task('deploy-fonts', function () {
    return gulp.src(config.fonts)
                .pipe(gulp.dest(config.dist.font));
});

gulp.task('deploy-views', function () {
    return gulp.src(config.app.html)
                .pipe(gulp.dest(config.dist.app));
});

gulp.task('deploy-images', function () {
    log('Copying and compressing the images');
    return gulp.src(config.app.images)
                .pipe(loader.imagemin({
                    progressive: true, //jpg
                    interlaced: true, //gif
                    optmizationLevel: 7  // 0 - 7
                }))
                .pipe(gulp.dest(config.dist.app));
});
