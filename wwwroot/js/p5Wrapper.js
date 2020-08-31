
function startP5(p5Implementation, container) {
    let sketch = function(p) {
        window.p5Instance = p;

        p.fonts = {};
        p.images = {};
        p.models = {};

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
            this.image(
                this.images[id],
                x,
                y,
                width,
                height
            );
        }

        p.imageHeightDotnet = function(id) {
            return this.images[id].height;
        }

        p.imageWidthDotnet = function(id) {
            return this.images[id].width;
        }
        
        p.invokeP5Function = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);
            this[functionName].apply(this, args);
        }

        p.invokeP5FunctionAndReturn = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);u
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
            this.images[id].loadPixels();
        }

        p.modelDotnet = function(id) {
            this.model(this.models[id]);
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
        
        p.setup = function() {
            p5Implementation.invokeMethod('setup');
        }

        p.textFontDotnet = function(id, size) {
            if (!size) {
                this.textFont(this.fonts[id]);
            } else {
                this.textFont(this.fonts[id], size);
            }
        }

        p.textureDotnet = function(id) {
            let image = this.images[id];
            if (!image) {
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