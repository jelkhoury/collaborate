var gulp = require("gulp"),
    fs = require("fs"),
    sass = require("gulp-sass");

// other content removed

gulp.task("sass", function () {
    return gulp.src(['wwwroot/css/main.scss', 'node_modules/@angular/material/prebuilt-themes/deeppurple-amber.css'])
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});


//<link href=" ../node_modules/@angular/material/prebuilt-themes/pink-bluegrey.css" rel="stylesheet">
