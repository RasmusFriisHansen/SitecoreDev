var gulp = require('gulp'),
    msbuild = require("gulp-msbuild"),
    debug = require("gulp-debug"),
    foreach = require("gulp-foreach");

var gulpConfig = require("./gulp-config.js")();

module.exports.config = gulpConfig;
gulp.task("Publish-Site", function () {
    return gulp.src("./{Feature,Foundation,Project}/**/**/*.csproj")
        .pipe(foreach(function (stream, file) {
            return stream
                .pipe(debug({ title: "Publishing website " }))
                .pipe(msbuild({
                    toolsVersion: 14.0,
                    properties: { VisualStudioVersion: 14.0 },
                    targets: ["Build"],
                    gulpConfiguration: gulpConfig.buildConfiguration,
                    properties: {
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

