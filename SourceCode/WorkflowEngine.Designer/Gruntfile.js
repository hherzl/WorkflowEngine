module.exports = function (grunt) {
    grunt.initConfig({
        //this loads our packages for our grunt file
        pkg: grunt.file.readJSON('package.json'),

        //this section does our bower installs for us
        bower: {
            install: {
                options: {
                    targetDir: './scripts/vendor',
                    layout: 'byComponent',
                    install: true,
                    verbose: true,
                    cleanTargetDir: false,
                    cleanBowerDir: false,
                    bowerOptions: {}
                }
            }
        },

        //this section is used to join our js files together
        concat: {
            options: {
                separator: ';',
                stripBanners: true,
                banner: '/*! <%= pkg.name %> - v<%= pkg.version %> - ' +
                  '<%= grunt.template.today("mm-dd-yyyy") %> */',
            },
            devSrc: {
                src: ['scripts/vendor/jquery/*.js',
            'scripts/vendor/leaflet/*.js',
                    'scripts/vendor/leaflet-plugins/layer/tile/Google.js'],
                dest: 'scripts/vendor/dist/project-vendor-src.js',
            },
        },

        //this section is used to for our minify action
        uglify: {
            options: {
                banner: '/*! <%= pkg.name %> <%= grunt.template.today("yyyy-mm-dd") %> */\n'
            },
            build: {
                src: 'scripts/vendor/dist/project-vendor-src.js',
                dest: 'scripts/vendor/dist/project-vendor.min-<%= pkg.version %>.js'
            }
        }
    });

    //npm modules need for our task
    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-concat');

    //run bower for package install
    grunt.registerTask('install-bower-packages', ['bower']);

    //build vendor file src
    grunt.registerTask('merge-js-files', ['concat']);

    //build min vendor file from above
    grunt.registerTask('min-js-file', ['concat', 'uglify']);
};