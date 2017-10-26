var webpack = require('webpack');
var helpers = require('./helpers');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
module.exports = {
    devtool: 'inline-source-map',

    resolve: {
        extensions: ['.ts', '.js']
    },

    module: {
        rules: [
            {
                test: /\.ts$/,
                loaders: [
                    {
                        loader: 'awesome-typescript-loader',
                        options: { configFileName: helpers.root('src', 'tsconfig.json') }
                    }, 'angular2-template-loader'
                ],
                exclude: [/node_modules\/(?!(ng2-.+|ngx-.+))/]
            },
            {
                test: /\.html$/,
                loader: 'html-loader'

            },
            {
                test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
                loader: 'null-loader'
            },
            {
                test: /\.css$/,
                exclude: helpers.root('src', 'app'),
                loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: 'css-loader?sourceMap' })
            },

            {
                test: /\.css$/,
                include: helpers.root('src', 'app'),
                loader: 'raw-loader'
            },
            {
                test: /\.scss$/,
                exclude: /node_modules/,
                loaders: ['raw-loader', 'sass-loader'] // sass-loader not scss-loader
            },
            // {
            //     test: /\.scss$/, 
            //     loader: ExtractTextPlugin.extract(['style-loader', 'css-loader', 'sass-loader']),
            //     exclude: [helpers.root('src/index.html')]
            // },
            // {
            //     test: /\.scss$/,
            //     exclude: helpers.root('src', 'app'),
            //     loader: 'null-loader'
            // },
            // {
            //     test: /\.css$/,
            //     exclude: helpers.root('src', 'app'),
            //     loader: 'null-loader'
            // },
            // {
            //     test: /\.scss$/,
            //     include: helpers.root('src', 'app'),
            //     loader: 'raw-loader'
            // },
            // {
            //     test: /\.css$/,
            //     include: helpers.root('src', 'app'),
            //     loader: 'raw-loader'
            // },
            {
                enforce: 'post',
                test: /\.(js|ts)$/,
                loader: 'istanbul-instrumenter-loader',
                include: helpers.root('src'),
                exclude: [
                    /\.(e2e|spec)\.ts$/,
                    /node_modules/
                ]
            }
        ]
    },

    plugins: [
        new webpack.ContextReplacementPlugin(
            // The (\\|\/) piece accounts for path separators in *nix and Windows
            /angular(\\|\/)core(\\|\/)@angular/,
            helpers.root('./src'), // location of your src
            {} // a map of your routes
        )
    ]
}