
function startP5(p5Implementation, container) {
    let sketch = function(p) {
        window.p5Instance = p;

        // #region Main functions
        p.deviceMoved = function() {
            p5Implementation.invokeMethod('deviceMoved');
        }

        p.deviceShaken = function() {
            p5Implementation.invokeMethod('deviceShaken');
        }

        p.deviceTurned = function() {
            p5Implementation.invokeMethod('deviceTurned');
        }

        p.disableFriendlyErrorsDotnet = function(value) {
            this.disableFriendlyErrors = !!value;
        }

        p.doubleClicked = function() {
            return p5Implementation.invokeMethod('doubleClicked');
        }

        p.draw = function() {
            p5Implementation.invokeMethod('draw');
        }

        p.getValue = function(valueName) {
            return this[valueName];
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
        // #endregion

        // #region Camera
        p.cameras = {};
        p.nextCameraId = 0;

        p._getCamera = function(id) {
            let camera = this.cameras[id];
            if (!camera) {
                console.error(`Camera with id '${id}' is not loaded`);
                return null;
            }
            return camera;
        }
        
        p.createCameraDotnet = function() {
            p.cameras[p.nextCameraId] = this.createCamera();
            return {
                id: p.nextCameraId++,
            };
        }

        p.frustumDotnet = function(id, left, right, bottom, top, near, far) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.frustum(left, right, bottom, top, near, far);
        }

        p.lookAtDotnet = function(id, x, y, z) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.lookAt(x, y, z);
        }

        p.moveDotnet = function(id, x, y, z) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.move(x, y, z);
        }

        p.orthoDotnet = function(id, left, right, bottom, top, near, far) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.ortho(left, right, bottom, top, near, far);
        }

        p.panDotnet = function(id, angle) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.pan(angle);
        }

        p.perspectiveDotnet = function(id, fovY, aspect, near, far) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.perspective(fovY, aspect, near, far);
        }

        p.setCameraDotnet = function(id) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            this.setCamera(camera);
        }

        p.setCameraParametersDotnet = function(id, x, y, z, centerX, centerY, centerZ, upX, upY, upZ) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.camera(x, y, z, centerX, centerY, centerZ, upX, upY, upZ);
        }
        
        p.setCameraPositionDotnet = function(id, x, y, z) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.setPosition(x, y, z);
        }

        p.tiltDotnet = function(id, angle) {
            let camera = this._getCamera(id);
            if (!camera) {
                return;
            }
            camera.tilt(angle);
        }
        // #endregion

        // #region Font
        p.fonts = {};

        p._getFont = function(id) {
            let font = this.fonts[id];
            if (!font) {
                console.error(`Font with id '${id}' is not loaded`);
                return null;
            }
            return font;
        }

        p.fontDotnet = function(id, size) {
            let font = this._getFont(id);
            if (!font) {
                return;
            }
            if (!size) {
                this.textFont(font);
            } else {
                this.textFont(font, size);
            }
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

        p.textFontDotnet = function(id, size) {
            let font = this._getFont(id);
            if (!font) {
                return;
            }
            if (!size) {
                this.textFont(this.fonts[id]);
            } else {
                this.textFont(this.fonts[id], size);
            }
        }
        // #endregion

        // #region Image
        p.images = {};

        p._getImage = function(id) {
            let image = this.images[id];
            if (!image) {
                console.error(`Image with id '${id}' is not loaded`);
                return null;
            }
            return image;
        }

        p.imageDotnet = function(id, x, y, width, height) {
            let image = this._getImage(id);
            if (!image) {
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
            let image = this._getImage(id);
            if (!image) {
                return;
            }
            return image.height;
        }

        p.imageWidthDotnet = function(id) {
            let image = this._getImage(id);
            if (!image) {
                return;
            }
            return image.width;
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

        p.loadPixelsDotnet = function(id) {
            let image = this._getImage(id);
            if (!image) {
                return;
            }
            image.loadPixels();
        }

        p.textureDotnet = function(id) {
            let image = this._getImage(id);
            if (!image) {
                return;
            }
            this.texture(image);
        }
        // #endregion

        // #region Model
        p.models = {};

        p._getModel = function(id) {
            let model = this.models[id];
            if (!model) {
                console.error(`Model with id '${id}' is not loaded`);
                return null;
            }
            return model;
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

        p.modelDotnet = function(id) {
            let model = this._getModel(id);
            if (!model) {
                return;
            }
            this.model(model);
        }
        // #endregion

        // #region Shader
        p.shaders = {};

        p._getShader = function(id) {
            let shader = this.shaders[id];
            if (!shader) {
                console.error(`Shader with id '${id}' is not loaded`);
                return null;
            }
            return shader;
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

        p.shaderDotnet = function(id) {
            let shader = this._getShader(id);
            if (!shader) {
                return;
            }
            this.shader(shader);
        }

        p.setUniformDotnet = function(id, uniformName, value) {
            let shader = this._getShader(id);
            if (!shader) {
                return;
            }
            shader.setUniform(uniformName, value);
        }
        // #endregion

        // #region Sound
        p.sounds = {};

        p._getSound = function(id) {
            let sound = this.sounds[id];
            if (!sound) {
                console.error(`Sound with id '${id}' is not loaded`);
                return null;
            }
            return sound;
        }

        p.getCurrentTimeDotnet = function(id) {
            let sound = this._getSound(id);
            if (!sound) {
                return 0.0;
            }
            return sound.currentTime();
        }

        p.getDurationDotnet = function(id) {
            let sound = this._getSound(id);
            if (!sound) {
                return 0.0;
            }
            return sound.duration();
        }

        p.getPanSoundDotnet = function(id) {
            let sound = this._getSound(id);
            if (!sound) {
                return 0.0;
            }
            return sound.getPan();
        }

        p.isLoadedDotnet = function(id) {
            let sound = this._getSound(id);
            return !sound ? false : sound.isLoaded();
        }

        p.isLoopingDotnet = function(id) {
            let sound = this._getSound(id);
            return !sound ? false : sound.isLooping();
        }
        
        p.isPausedDotnet = function(id) {
            let sound = this._getSound(id);
            return !sound ? false : sound.isPaused();
        }

        p.isPlayingDotnet = function(id) {
            let sound = this._getSound(id);
            return !sound ? false : sound.isPlaying();
        }

        p.loadSoundDotnet = function(soundPath) {
            if (!this.sounds[soundPath])
            {
                this.sounds[soundPath] = this.loadSound(soundPath);
            }
            return {
                id: soundPath,
            };
        }

        p.loopDotnet = function(id, startTime, rate, amp, cueStart, duration) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.loop(
                startTime,
                rate,
                amp,
                cueStart === null ? undefined : cueStart,
                duration === null ? undefined : duration
            );
        }

        p.panSoundDotnet = function(id, panValue, delay) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.pan(panValue, delay);
        }

        p.pauseDotnet = function(id, delay) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.pause(delay);
        }

        p.playDotnet = function(id, startTime, rate, amp, cueStart, duration) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.play(
                startTime,
                rate,
                amp,
                cueStart === null ? undefined : cueStart,
                duration === null ? undefined : duration
            );
        }

        p.playModeDotnet = function(id, mode) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.playMode(mode);
        }

        p.setIsLoopingDotnet = function(id, shouldLoop) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.setLoop(shouldLoop);
        }

        p.setRateDotnet = function(id, rate) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.rate(rate);
        }

        p.setVolumeDotnet = function(id, volume, rampTime, delay) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.setVolume(volume, rampTime, delay);
        }

        p.stopDotnet = function(id, delay) {
            let sound = this._getSound(id);
            if (!sound) {
                return;
            }
            sound.stop(delay);
        }
        // #endregion
    };
    new p5(sketch, document.getElementById(container));
}