var webpackConfig = require('./webpack.test');

module.exports = function (config) {
    var _config = {
        basePath: '',

        frameworks: ['jasmine'],

        files: [
            {pattern: './config/karma-test-shim.js', watched: false}
        ],

        preprocessors: {
            './config/karma-test-shim.js': ['coverage', 'webpack', 'sourcemap']
        },

        webpack: webpackConfig,

        webpackMiddleware: {
            stats: 'errors-only'
        },

        webpackServer: {
            noInfo: true
        },
        coverageReporter: {
            type: 'in-memory'
        },
        browserNoActivityTimeout: 100000,

        remapCoverageReporter: {
            'text-summary': null,
            json: './coverage/coverage.json',
            html: './coverage/html'
        },


        reporters: ['progress', 'coverage', 'remap-coverage'],
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        browsers: ['PhantomJS']
    };

    config.set(_config);
};