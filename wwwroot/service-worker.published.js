// service-worker.published.js

self.importScripts('./service-worker-assets.js');

const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${self.assetsManifest.version}`;
const offlineAssetsInclude = [/\.dll$/, /\.pdb$/, /\.wasm$/, /\.html$/, /\.js$/, /\.json$/, /\.css$/, /\.woff2?$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/];
const offlineAssetsExclude = [/^service-worker\.js$/];

self.addEventListener('install', event => {
    event.waitUntil(onInstall());
});

self.addEventListener('activate', event => {
    event.waitUntil(onActivate());
});

self.addEventListener('fetch', event => {
    event.respondWith(onFetch(event));
});

async function onInstall() {
    const cache = await caches.open(cacheName);
    const toCache = self.assetsManifest.assets
        .filter(asset => offlineAssetsInclude.some(p => p.test(asset.url)))
        .filter(asset => !offlineAssetsExclude.some(p => p.test(asset.url)))
        .map(asset => new Request(asset.url, { integrity: asset.hash, cache: 'no-cache' }));

    await cache.addAll(toCache);
}

async function onActivate() {
    const cacheKeys = await caches.keys();
    await Promise.all(
        cacheKeys
            .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
            .map(key => caches.delete(key))
    );
}

async function onFetch(event) {
    const url = new URL(event.request.url);

    // Ignora requisições externas (ex: Google Analytics, fontes externas)
    if (url.origin !== self.origin) {
        return fetch(event.request);
    }

    if (event.request.method !== 'GET') {
        return fetch(event.request);
    }

    const cache = await caches.open(cacheName);
    const cachedResponse = await cache.match(event.request);
    return cachedResponse || fetch(event.request);
}
