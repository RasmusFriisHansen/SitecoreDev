var gulp = require('gulp'),
    cssmin = require("gulp-cssmin"),
    rename = require("gulp-rename"),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify"),
    msbuild = require("gulp-msbuild"),
    debug = require("gulp-debug"),
    foreach = require("gulp-foreach"),
    gulpConfig = require("./gulp-config.js")();

module.exports.config = gulpConfig;
gulp.task("Publish-Site", function () {
    return gulp.src("./{Feature,Foundation,Project}/**/**/*.csproj")
        .pipe(foreach(function (stream, file) {
            return stream
                .pipe(debug({ title: "Publishing website " }))
                .pipe(msbuild({
                    toolsVersion: 14.0,
                    targets: ["Build"],
                    gulpConfiguration: gulpConfig.buildConfiguration,
                    properties: {
                        VisualStudioVersion: 14.0,
                        publishUrl: gulpConfig.webRoot,
                        DeployDefaultTarget: "WebPublish",
                        WebPublishMethod: "FileSystem",
                        DeployOnBuild: "true",
                        DeleteExistingFiles: "false",
                        _FindDependencies: "false"
                    }
                }));
        }));
});

var minifyCss = function (destination) {
    gulp.src("./{Feature,Foundation,Project}/**/**/Content/*.css")
        .pipe(concat('sitecoredev.website.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest(destination));
};

var minifyJs = function (destination) {
    gulp.src("./{Feature,Foundation,Project}/**/**/Scripts/*.js")
        .pipe(concat('sitecoredev.website.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(destination));
};

gulp.task("minify-css", function () {
    minifyCss();
});

gulp.task("minify-js", function () {
    minifyJs
});

gulp.task("css-watcher", function () {
    var root = "./";
    var roots = [root + "**/Content", "!" + root + "/**/obj/**/Content"];
    var files = "/**/*.css";
    var destination = gulpConfig.webRoot + "\\Content";
    gulp.src(roots, { base: root }).pipe(
        foreach(function (stream, rootFolder) {
            gulp.watch(rootFolder.path + files, function (event) {
                if (event.type === "changed") {
                    console.log("publish this file " + event.path);
                    minifyCss(destination);
                }
                console.log("published " + event.path);
            });
            return stream;
        })
    );
});

gulp.task("js-watcher", function () {
    var root = "./";
    var roots = [root + "**/Scripts", "!" + root + "/**/obj/**/Scripts"];
    var files = "/**/*.js";
    var destination = gulpConfig.webRoot + "\\Scripts";
    gulp.src(roots, { base: root }).pipe(
        foreach(function (stream, rootFolder) {
            gulp.watch(rootFolder.path + files, function (event) {
                if (event.type === "changed") {
                    console.log("publish this file " + event.path);
                    minifyJs(destination);
                }
                console.log("published " + event.path);
            });
            return stream;
        })
    );
});

