var gulp = require("gulp"),
    fs = require("fs"),
    sass = require("gulp-sass");

// other content removed

var src = ['wwwroot/css/main.scss', 'node_modules/@angular/material/prebuilt-themes/deeppurple-amber.css'];

gulp.task("sass", function () {
    return gulp.src(src)
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch', function () {
    gulp.watch(src, ['build']);
})

//<link href=" ../node_modules/@angular/material/prebuilt-themes/pink-bluegrey.css" rel="stylesheet">
