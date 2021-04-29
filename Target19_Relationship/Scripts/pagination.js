const pagination = (url) => {
    let pageNo = 0;
    let pagestring = '';
    $.getJSON(url, function (data) {
        const row = Number(data.status);
        if (Math.floor(row % 8) === 0) {
            pageNo = Array(Math.floor(row / 8));
        }
        else {
            pageNo = Array(Math.floor(row / 8) + 1);
        }
        if (pageNo.length <= 8) {
            for (var i = 0; i < pageNo.length; i++) {
                var j = i + 1;
                pageNo[i] = '<button type=\"button\" class=\"btn btn-default\" data-page=\"' + j + '\">' + j + '</button>';
            }
            pagestring = pageNo.join('');
            $('#pagiNation').html(pagestring);
        }
        else {
            //ページ数が9以上のときの処理
            for (i = 0; i < 8; i++) {
                j = i + 1;
                pageNo[i] = '<button type=\"button\" class=\"btn btn-default\" data-page=\"' + j + '\">' + j + '</button>';
            }
            const endNo = pageNo.length;//定数にしないと最大ページ数が2加算されます。
            pageNo.unshift('<button type=\"button\" class=\"btn btn-default\" id=\"Prev\">&laquo;</button>');
            pageNo.push('<button type=\"button\" class=\"btn btn-default\" id=\"Next\">&raquo;</button>');
            pageNo.push('<button type=\"button\" class=\"btn btn-default\" data-page=\"' + endNo + '\">' + endNo + '</button>');
            pagestring = pageNo.join('');
            $('#pagiNation').html(pagestring);
        }
    });
};