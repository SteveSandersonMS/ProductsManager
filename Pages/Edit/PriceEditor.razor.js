import '/imask/imask.js';

export function attach(elem) {
    const mask = IMask(elem, {
        mask: Number,
        scale: 2,
        thousandsSeparator: ',',
        radix: '.',
        padFractionalZeros: true,
        normalizeZeros: true,
    });
}
