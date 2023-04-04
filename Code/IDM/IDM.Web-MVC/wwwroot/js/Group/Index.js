function GetSGByInternalID() {
    var dataContent = $("#data");
    var url = '/SecurityGroup/GetSGByInternalID?internalID=44F0E22B-2A08-441A-9E42-8C05D4F33EFC';
    $(dataContent).load(url + " #data");
}