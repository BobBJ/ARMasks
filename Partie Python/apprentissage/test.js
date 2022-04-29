const axios = require("axios");

const slackToken =
  "xoxb-YOUR-xoxb-3395519405008-3374198483860-s4MtusGV99Jll6jarRBcTVsA";

run().catch((err) => console.log(err));

async function run() {
  const url = "https://slack.com/api/chat.postMessage";
  const res = await axios.post(
    url,
    {
      channel: "#ar-masks-landmarks",
      text: "Hello, World!",
      username: "Test App",
      icon_emoji: ":+1:",
    },
    { headers: { authorization: `Bearer ${slackToken}` } }
  );

  console.log("Done", res.data);
}
