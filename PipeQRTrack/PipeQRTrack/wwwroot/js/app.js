window.printImage = function (imageUrl) {
    var win = window.open('');
    win.document.write(`
        <html>
        <head>
            <style>
                body {
                    margin: 0;
                    padding: 0;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    height: 100vh;
                }
                img {
                    max-width: 100%;
                    max-height: 100%;
                    object-fit: contain;
                }
                @media print {
                    @page {
                        size: auto;
                        margin: 0mm;
                    }
                    body {
                        margin: 0;
                        padding: 0;
                    }
                }
            </style>
        </head>
        <body>
            <img src="${imageUrl}" onload="window.print();window.close()"/>
        </body>
        </html>
    `);
    win.document.close();
    win.focus();
}