def fct():
    channel_id = "C03AR3EGX54"
    try:
        # Call the chat.postMessage method using the WebClient
        result = client.chat_postMessage(
            token="xoxb-3395519405008-3374198483860-s4MtusGV99Jll6jarRBcTVsA",
            channel=channel_id,
            text="Hello world"
        )
        logger.info(result)

    except SlackApiError as e:
        logger.error(f"Error posting message: {e}")
