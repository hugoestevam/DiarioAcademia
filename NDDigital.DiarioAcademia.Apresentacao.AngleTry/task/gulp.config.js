module.exports = function () {

    // MAIN PATHS
    var paths = {
        app: './src/',
        scripts: 'js/'
    };
    var bower = "./bower_components/";

    var config = {

        root: "./",

        index: "./index.html",

        // production mode (see build task)
        isProduction: false,

        // Angular template cache
        // Example:
        //    gulp --usecache
        useCache: args.usecache,

        app: {
            html: [paths.app + "**/**/*.html"],

            js: {
                modules: [paths.app + '**/**/*.module.js'],
                extentions: [paths.app + 'common/extentions/*.js'],
                configs: [paths.app + "**/**/*.config.js", '!' + paths.app + "common/routes/routes.config.js"],
                constant: [paths.app + "**/**/*.constants.js"],
                provider: [paths.app + "**/**/*.provider.js"],
                adapters: [paths.app + "**/**/*.adapter.js"],
                factory: [paths.app + "**/**/*.factory.js"],
                services: [paths.app + '**/**/*.service.js'],
                controllers: [  // if you have more static controllers: use .json with require() here
                    paths.app + 'common/layout/shell.controller.js',
                    paths.app + 'common/sidebar/sidebar.controller.js',
                    paths.app + 'common/sidebar/sidebar.userblock.controller.js'
                ],
                route: [paths.app + '**/**/*.routes.js'],
                routeConfig: [paths.app + 'common/routes/routes.config.js'],
                directive: [paths.app + "**/**/*.directive.js"],
                run: [paths.app + "**/**/*.run.js"]
            },

            less: {
                all: "./src/content/**/**/**/*.less",
                app: ["./src/content/**/**/*.less", "!./src/content/libs/**/*.less"],
                bootstrap: "./src/vendor/bootstrap/bootstrap.less",
                angle: "./src/content/libs/app/app.less"
            },


            distCss: "./src/content/css/",

            css: ["./src/content/**/**/*.css",
                "!./src/content/theme/theme*.css",
                "!./src/content/**/**/bootstrap*.css"
            ],


            appcss: "./src/content/css/**/app.css"

        },

        libs: {
            css: [bower + "/**/**/**/*.css",
                 "./src/content/css/bootstrap.css",
                 "!" + bower + "**/**/**/*.min.css",
                 "!" + bower + "**/**/**/bootstrap*.css",
                 "!" + bower + "/modernizr/**/*.css",
                 "!" + bower + "/ng-table/docs/**/*.css"]

        },

        bower: {
            json: require("../bower.json"),
            directory: "./bower_components",
            ignorePath: "../"
        },

        dist: {
            root: "./dist"
        },

        clean: {
            distCss: "./src/content/css/**/**/*.css",
            dist: "./dist/**/**/*.*",
        },

        templatecache: {
            path: "./src/common/templatecache/",
            file: "templates.js",
            options: {
                module: 'diarioacademia',
                standAlone: false,
                root: './src/'
            }
        },
    };

    // Resources
    config.getResourcesInjected = function () {
        return {
            'modules': config.app.js.modules,
            'extentions': config.app.js.extentions,
            'provider': config.app.js.provider,
            'config': config.app.js.configs,
            'constant': config.app.js.constant,
            'adapters': config.app.js.adapters,
            'factory': config.app.js.factory,
            'service': config.app.js.services,
            'controller.static': config.app.js.controllers,
            'routes': config.app.js.route,
            'config.routes': config.app.js.routeConfig,
            'directive': config.app.js.directive,
            'templates': config.templatecache.path + config.templatecache.file,
            'run': config.app.js.run,
        }
    }

    // Wiredep
    config.getWiredepDefaultOptions = function () {
        return {
            bower: config.bower.json,
            diretory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
            devDependencies: false,
            fileTypes: {
                html: {
                    replace: {
                        js: '<script src="/{{filePath}}"></script>'
                    }
                }
            },
            exclude: require("../src/vendor/vendor.json")
        };
    }

    //Browsersync
    config.getBrowsersyncOptions = function () {
        return {
            server: {
                baseDir: "./"
            },
            //watcher for restart
            files: [
               'src/**/**/**/**/*.js',
               '**/**/**/*.html'
            ],
            ghostMode: {
                clicks: true,
                location: false,
                forms: true,
                scroll: true
            },
            injectChanges: true, // injetar modificações
            logFilesChanges: true,
            logLevel: 'debug',
            log: 'gulp-patterns',
            notify: true,
            reloadDelay: 0
        };
    }

    return config;
}