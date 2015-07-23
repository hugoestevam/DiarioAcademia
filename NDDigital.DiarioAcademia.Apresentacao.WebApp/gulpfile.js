/*
 * Gulp Main
 *
 */

// GLOBAL VARIABLES
gulp = require('gulp');
config = require('./task/gulp.config.js')();
loader = require('gulp-load-plugins')({ lazy: true });
del = require('del');
requireDir = require('require-dir');
util = require('./task/util/util.js')();
log = util.log;
connect = require('gulp-connect');

// TASKS
requireDir('./task/');

// list tasks
gulp.task('default', ['help']);
gulp.task('help', loader.taskListing);