
function startP5(p5Implementation, container) {
    let sketch = function(p) {
        window.p5Instance = p;

        p.fonts = {};
        p.images = {};
        p.models = {};
        p.shaders = {};

        p.deviceMoved = function() {
            p5Implementation.invokeMethod('deviceMoved');
        }

        p.deviceShaken = function() {
            p5Implementation.invokeMethod('deviceShaken');
        }

        p.deviceTurned = function() {
            p5Implementation.invokeMethod('deviceTurned');
        }

        p.doubleClicked = function() {
            return p5Implementation.invokeMethod('doubleClicked');
        }

        p.draw = function() {
            p5Implementation.invokeMethod('draw');
        }

        p.fontDotnet = function(id, size) {
            let font = this.fonts[id];
            if (!font) {
                console.error(`Font with id '${id}' is not loaded`);
                return;
            }
            if (!size) {
                this.textFont(font);
            } else {
                this.textFont(font, size);
            }
        }

        p.getValue = function(valueName) {
            return this[valueName];
        }

        p.imageDotnet = function(id, x, y, width, height) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return;
            }
            this.image(
                image,
                x,
                y,
                width,
                height
            );
        }

        p.imageHeightDotnet = function(id) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return;
            }
            return image.height;
        }

        p.imageWidthDotnet = function(id) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return;
            }
            return image.width;
        }
        
        p.invokeP5Function = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);
            this[functionName].apply(this, args);
        }

        p.invokeP5FunctionAndReturn = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);
            return this[functionName].apply(this, args);
        }

        p.keyPressed = function() {
            return p5Implementation.invokeMethod('keyPressed');
        }

        p.keyReleased = function() {
            return p5Implementation.invokeMethod('keyReleased');
        }

        p.keyTyped = function() {
            return p5Implementation.invokeMethod('keyTyped');
        }

        p.loadFontDotnet = function(fontPath) {
            if (!this.fonts[fontPath])
            {
                this.fonts[fontPath] = this.loadFont(fontPath);
            }
            return {
                id: fontPath,
            };
        }
        
        p.loadImageDotnet = function(imagePath) {
            if (!this.images[imagePath])
            {
                this.images[imagePath] = this.loadImage(imagePath);
            }
            return {
                id: imagePath,
            };
        }

        p.loadModelDotnet = function(modelPath, normalize) {
            if (!this.models[modelPath])
            {
                this.models[modelPath] = this.loadModel(modelPath, normalize);
            }
            return {
                id: modelPath,
            };
        }

        p.loadPixelsDotnet = function(id) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return;
            }
            image.loadPixels();
        }

        p.loadShaderDotnet = function(vertexShaderPath, fragmentShaderPath) {
            let id = `${vertexShaderPath}-${fragmentShaderPath}`;
            if (!this.shaders[id])
            {
                this.shaders[id] = this.loadShader(vertexShaderPath, fragmentShaderPath);
            }
            return {
                id,
            };
        }

        p.modelDotnet = function(id) {
            let model = this.models[id];
            if (!model) {
                console.error(`Model with id '${id}' is not loaded`);
                return;
            }
            this.model(model);
        }

        p.mouseClicked = function() {
            return p5Implementation.invokeMethod('mouseClicked');
        }

        p.mouseDragged = function() {
            return p5Implementation.invokeMethod('mouseDragged');
        }

        p.mouseMoved = function() {
            return p5Implementation.invokeMethod('mouseMoved');
        }

        p.mousePressed = function() {
            return p5Implementation.invokeMethod('mousePressed');
        }

        p.mouseReleased = function() {
            return p5Implementation.invokeMethod('mouseReleased');
        }

        p.mouseWheel = function(event) {
            return p5Implementation.invokeMethod('mouseWheel', event.delta);
        }

        p.preload = function() {
            p5Implementation.invokeMethod('preload');
        }

        p.setUniformDotnet = function(id, uniformName, value) {
            let shader = this.shaders[id];
            if (!shader) {
                console.error(`Shader with id '${id}' is not loaded`);
                return;
            }
            shader.setUniform(uniformName, value);
        }
        
        p.setup = function() {
            p5Implementation.invokeMethod('setup');
        }
        
        p.shaderDotnet = function(id) {
            let shader = this.shaders[id];
            if (!shader) {
                console.error(`Shader with id '${id}' is not loaded`);
                return;
            }
            this.shader(shader);
        }

        p.textFontDotnet = function(id, size) {
            let font = this.fonts[id];
            if (!font) {
                console.error(`Font with id '${id}' is not loaded`);
                return;
            }
            if (!size) {
                this.textFont(this.fonts[id]);
            } else {
                this.textFont(this.fonts[id], size);
            }
        }

        p.textureDotnet = function(id) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return;
            }
            this.texture(image);
        }

        p.touchEnded = function() {
            return p5Implementation.invokeMethod('touchEnded');
        }

        p.touchMoved = function() {
            return p5Implementation.invokeMethod('touchMoved');
        }

        p.touchStarted = function() {
            return p5Implementation.invokeMethod('touchStarted');
        }

        p.windowResized = function() {
            p5Implementation.invokeMethod('windowResized');
        }
    };
    new p5(sketch, document.getElementById(container));
}