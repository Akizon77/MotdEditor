async function copyToClipboard() {
    const outputText = document.querySelector('.output').innerText;
    const p = document.querySelector('.notice-copy-success');
    try {
        await navigator.clipboard.writeText(outputText);
        p.setAttribute('style', 'opacity: 100');
        setTimeout(() => {
            p.setAttribute('style', 'opacity: 0');
        }, 1000);
    } catch (err) {
        console.log(err);
        p.innerText = '复制失败';
        p.setAttribute('style', 'opacity: 100');
        setTimeout(() => {
            p.setAttribute('style', 'opacity: 0');
            setTimeout(() => {
                p.innerText = '成功复制到剪切板';
            }, 300);
        }, 1000);
    }
}

window.onload = function () {
    const input1 = document.getElementById('motd-line-1');
    const input2 = document.getElementById('motd-line-2');

    input1.value = localStorage.getItem('motd-line-1') || '';
    input2.value = localStorage.getItem('motd-line-2') || '';
    setPreview();
    setOutput();
    setButtonpanel();
};

function setButtonpanel() {
    const panel = document.getElementById('details-root-button-panel');
    const fmtpanel = document.getElementById('details-root-fmt-panel');
    const colorMap = {
        '0': '#000000',
        '1': '#0000AA',
        '2': '#00AA00',
        '3': '#00AAAA',
        '4': '#AA0000',
        '5': '#AA00AA',
        '6': '#FFAA00',
        '7': '#AAAAAA',
        '8': '#555555',
        '9': '#5555FF',
        'a': '#55FF55',
        'b': '#55FFFF',
        'c': '#FF5555',
        'd': '#FF55FF',
        'e': '#FFFF55',
        'f': '#FFFFFF'
    };

    for (let key in colorMap) {
        if (colorMap.hasOwnProperty(key)) {
            let btn = document.createElement('button')
            btn.style.borderColor = "#0000003c"
            btn.style.backgroundColor = colorMap[key];
            btn.style.width = '48px';
            btn.style.height = '48px';
            btn.textContent = key;
            btn.style.color = "#7c7c7c";
            btn.style.float = "left";
            panel.appendChild(btn);
        }
    }

    
    const formatMap = {
        'k': 'font-weight:normal;',
        'l': 'font-weight:bold;',
        'm': 'text-decoration:line-through;',
        'n': 'text-decoration:underline;',
        'o': 'font-style:italic;',
        'r': 'font-style:normal;'
    };
    const formatDescMap = {
        'k': '混乱显示 Obfuscated',
        'l': '加粗 Bold',
        'm': '删除线 Strikethrough',
        'n': '下划线 Underline',
        'o': '斜体 Italic',
        'r': '重置 Reset'
    };

    for (let key in formatMap) {
        if (formatMap.hasOwnProperty(key)) {
            fmtpanel.innerHTML += `<div style=\"display: flex;flex-direction: row;\"><span class=\"fmt-code-title\">§${key}</span><span class=\"fmt-code-value\" style="${formatMap[key]}">${formatDescMap[key]}</span></div>`;
        }
    }

}
function onInput() {
    saveToLocalStorage();
    setPreview();
    setOutput();
}

function setPreview() {
    const input1 = document.getElementById('motd-line-1').value;
    const input2 = document.getElementById('motd-line-2').value;
    const preview = document.querySelector('.preview-text');
    preview.innerHTML = "<p>" + parseMCmotdToHTML(input1) + "</p><p>" + parseMCmotdToHTML(input2) + "</p>";
}
function setOutput() {
    const input1 = document.getElementById('motd-line-1').value;
    const input2 = document.getElementById('motd-line-2').value;
    const output = document.querySelector('.output');
    output.innerText = stringToUnicodeExcludeASCII(input1) + "\\n" + stringToUnicodeExcludeASCII(input2);
}
function parseMCmotdToHTML(motd) {
    const colorMap = {
        '0': '#000000',
        '1': '#0000AA',
        '2': '#00AA00',
        '3': '#00AAAA',
        '4': '#AA0000',
        '5': '#AA00AA',
        '6': '#FFAA00',
        '7': '#AAAAAA',
        '8': '#555555',
        '9': '#5555FF',
        'a': '#55FF55',
        'b': '#55FFFF',
        'c': '#FF5555',
        'd': '#FF55FF',
        'e': '#FFFF55',
        'f': '#FFFFFF'
    };

    const formatMap = {
        'l': 'font-weight:bold;',
        'm': 'text-decoration:line-through;',
        'n': 'text-decoration:underline;',
        'o': 'font-style:italic;',
        'r': 'reset'
    };

    let html = '';
    let currentStyle = '';

    for (let i = 0; i < motd.length; i++) {
        if (motd[i] === '&') {
            i++;
            const code = motd[i];

            if (colorMap[code]) {
                currentStyle = `color:${colorMap[code]};`;
            } else if (formatMap[code]) {
                if (code === 'r') {
                    currentStyle = '';
                } else {
                    currentStyle += formatMap[code];
                }
            }
        } else {
            html += `<span style="${currentStyle}">${motd[i]}</span>`;
        }
    }

    return html;
}

function saveToLocalStorage() {
    const input1 = document.getElementById('motd-line-1').value;
    const input2 = document.getElementById('motd-line-2').value;

    localStorage.setItem('motd-line-1', input1);
    localStorage.setItem('motd-line-2', input2);
}
function stringToUnicodeExcludeASCII(str) {
    str = str.replace(/&/g, '§');
    let unicodeStr = '';
    for (let i = 0; i < str.length; i++) {
        let code = str.charCodeAt(i);
        if (code > 127) {
            let hex = code.toString(16).padStart(4, '0');
            unicodeStr += '\\u' + hex;
        } else {
            unicodeStr += str[i];
        }
    }
    return unicodeStr;
}

