/*
 * Gulp Main
 *
 */

// GLOBAL VARIABLES
gulp = require('gulp-help')(require('gulp'));
args = require('yargs').argv;
path = require('path'),
loader = require('gulp-load-plugins')({ lazy: true });
requireDir = require('require-dir');
browserSync = require('browser-sync').create();
config = require('./task/gulp.config.js')();
compileLess = require('gulp-less');
addsrc = require('gulp-add-src');
gulpsync = require('gulp-sync')(gulp);
del = require('del');
changed = require('gulp-changed');

// TASKS
requireDir('./task/');


gulp.task('default', ['help']);